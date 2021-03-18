using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Space StartingPosition;
    public Space GoalPosition;
    public ControlSettings Controls;
    private Space CurrentPosition;
    public GameObject Graphics;
    public GameObject BotsVoor;
    public GameObject BotsAchter;
    public GameObject BotsLinks;
    public GameObject BotsRechts;
    private Quaternion TargetRotation;
    private Vector3 TargetPosition;
    public float BotsAnimationTime = .3f;
    public bool AreWeAnimating = false;
    public bool AreWeFinished = false;
    public GameObject Confetti;
    public Stopwatch Timer;
    public TextMeshProUGUI TimerText;
    public SoundManager SM;
    public SceneNavigation SN;
    public string NextSceneName;
    public GameObject NextLevelTextObject;
    public Wiggle MouseWiggleComponent;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = StartingPosition;
        TargetPosition = CurrentPosition.transform.position+new Vector3(0,0,-1);
        ResetAllGraphics();

        NextLevelTextObject.SetActive(false);
        SM=GameObject.Find("SoundHandler").GetComponent<SoundManager>();
        //SM.PlayAchtergrondSound();
        Timer.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        DoTimerStuff();



        if (AreWeFinished)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                //Debug.LogError("NextLevel");
                SN.GoToScene(NextSceneName);

            }
        }
        else
        {

            if (Input.GetKeyUp(Controls.Up))
            {
                if (AreWeAnimating)
                {
                    ResetAllGraphics();
                    AreWeAnimating = false;
                }
                if (CurrentPosition.North.IsOpen)
                {
                    SM.PlayMoveSound();
                    TargetPosition = CurrentPosition.North.Connection.transform.position + new Vector3(0, 0, -1);
                    CurrentPosition = CurrentPosition.North.Connection.GetComponent<Space>();
                    TargetRotation = Quaternion.Euler(0, 0, 0);

                }
                else
                {
                    if ((int)transform.rotation.eulerAngles.z == 90)
                    {
                        StartCoroutine(BotsAnimatie(BotsRechts));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 270)
                    {
                        StartCoroutine(BotsAnimatie(BotsLinks));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 180)
                    {
                        StartCoroutine(BotsAnimatie(BotsAchter));
                    }
                    else
                    {
                        StartCoroutine(BotsAnimatie(BotsVoor));
                    }
                }
            }
            if (Input.GetKeyUp(Controls.Down))
            {
                if (AreWeAnimating)
                {
                    ResetAllGraphics();
                    AreWeAnimating = false;
                }
                if (CurrentPosition.South.IsOpen)
                {
                    SM.PlayMoveSound();
                    TargetPosition = CurrentPosition.South.Connection.transform.position + new Vector3(0, 0, -1);
                    CurrentPosition = CurrentPosition.South.Connection.GetComponent<Space>();
                    TargetRotation = Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    if ((int)transform.rotation.eulerAngles.z == 90)
                    {
                        StartCoroutine(BotsAnimatie(BotsLinks));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 270)
                    {
                        StartCoroutine(BotsAnimatie(BotsRechts));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 180)
                    {
                        StartCoroutine(BotsAnimatie(BotsVoor));
                    }
                    else
                    {
                        StartCoroutine(BotsAnimatie(BotsAchter));
                    }
                }
            }
            if (Input.GetKeyUp(Controls.Left))
            {
                if (AreWeAnimating)
                {
                    ResetAllGraphics();
                    AreWeAnimating = false;
                }
                if (CurrentPosition.West.IsOpen)
                {
                    SM.PlayMoveSound();
                    TargetPosition = CurrentPosition.West.Connection.transform.position + new Vector3(0, 0, -1);
                    CurrentPosition = CurrentPosition.West.Connection.GetComponent<Space>();
                    TargetRotation = Quaternion.Euler(0, 0, 90);
                }
                else
                {
                    if ((int)transform.rotation.eulerAngles.z == 90)
                    {
                        StartCoroutine(BotsAnimatie(BotsVoor));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 270)
                    {
                        StartCoroutine(BotsAnimatie(BotsAchter));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 180)
                    {
                        StartCoroutine(BotsAnimatie(BotsRechts));
                    }
                    else
                    {
                        StartCoroutine(BotsAnimatie(BotsLinks));
                    }
                }
            }
            if (Input.GetKeyUp(Controls.Right))
            {
                if (AreWeAnimating)
                {
                    ResetAllGraphics();
                    AreWeAnimating = false;
                }
                if (CurrentPosition.East.IsOpen)
                {
                    SM.PlayMoveSound();
                    TargetPosition = CurrentPosition.East.Connection.transform.position + new Vector3(0, 0, -1);
                    CurrentPosition = CurrentPosition.East.Connection.GetComponent<Space>();
                    TargetRotation = Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    if ((int)transform.rotation.eulerAngles.z == 90)
                    {
                        StartCoroutine(BotsAnimatie(BotsAchter));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 270)
                    {
                        StartCoroutine(BotsAnimatie(BotsVoor));
                    }
                    else if ((int)transform.rotation.eulerAngles.z == 180)
                    {
                        StartCoroutine(BotsAnimatie(BotsLinks));
                    }
                    else
                    {
                        StartCoroutine(BotsAnimatie(BotsRechts));
                    }
                }
            }

            transform.position = TargetPosition;
            transform.rotation = TargetRotation;





            if (CurrentPosition == GoalPosition)
            {
                SM.PlayGoalSound();
                AreWeFinished = true;
                Confetti.SetActive(true);
                Timer.Pause();
                NextLevelTextObject.SetActive(true);
                MouseWiggleComponent.enabled = true;
            }
        }

    }

    private IEnumerator BotsAnimatie(GameObject BotsObject)
    {
        SM.PlayBotsSound();
        AreWeAnimating = true;
        BotsObject.SetActive(true);
        Graphics.SetActive(false);

        yield return new WaitForSeconds(BotsAnimationTime);

        BotsObject.SetActive(false);
        Graphics.SetActive(true);
        AreWeAnimating = false;
    }
    private void ResetAllGraphics()
    {
        BotsVoor.SetActive(false);
        BotsAchter.SetActive(false);
        BotsLinks.SetActive(false);
        BotsRechts.SetActive(false);
        Graphics.SetActive(true);
        StopAllCoroutines();
    }
    private void DoTimerStuff()
    {
        if ((Timer.GetMilliseconds() * 100.0f) < 10.0f)
        {
            string s = "0" + (Timer.GetMilliseconds() * 100.0f).ToString("F0");
            TimerText.text = Timer.GetMinutes() + ":" + Timer.GetSeconds() + ":" + s;
        }
        else if ((int)(Timer.GetMilliseconds() * 100.0f) == 100)
        {
            TimerText.text = Timer.GetMinutes() + ":" + Timer.GetSeconds() + ":00";
        }
        else
        {
            TimerText.text = Timer.GetMinutes() + ":" + Timer.GetSeconds() + ":" + (Timer.GetMilliseconds() * 100.0f).ToString("F0");
        }
    }
}
