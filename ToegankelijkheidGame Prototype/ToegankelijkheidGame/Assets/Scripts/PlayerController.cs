using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct Tile
{
    public TileTypes Type;
}

public enum TileTypes
{
    Open,
    Wall,
    Start,
    Goal
}

public class PlayerController : MonoBehaviour
{
    public ControlSettings Controls;
    public int LevelWidth;
    public int LevelHeight;
    private int MoveScale=1;//How far does the mouse need to jump?
    public float RotationAnimationTime;
    public float MovingAnimationTime;

    private Quaternion TargetRotation;
    private Vector3 TargetPosition;
    [Multiline]
    public string LevelLayout= "XXXXXXXX\nXXX XX\nXXX X XX\nXXX X.\nX XXXX\nX XXXXXX\nX XXX\nXXXX XXX\nXXXX XXX\nXXXX XXX\nXXXXXXXX";
    private Tile[,] Layout;
    private int LayoutXIndex;
    private int LayoutYIndex;
    public GameObject OpenPrefab;
    public GameObject Graphics;
    public GameObject BotsVoor;
    public GameObject BotsAchter;
    public GameObject BotsLinks;
    public GameObject BotsRechts;
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

    // Start is called before the first frame update
    void Start()
    {
        NextLevelTextObject.SetActive(false);
        SM.PlayAchtergrondSound();
        ResetAllGraphics();
        Timer.Begin();

        Layout = new Tile[LevelWidth,LevelHeight];
        LevelParser(LevelLayout);
        //Debug.Log("X: " + LayoutXIndex + " - Y: " + LayoutYIndex);
        transform.position = new Vector3(LayoutXIndex, LayoutYIndex, 0);
        TargetPosition = transform.position;
        //Debug.Log(transform.position);
        //Debug.Log(Layout[3,3].Type);
        //Debug.Log(Layout[4, 4].Type);
    }

    // Update is called once per frame
    void Update()
    {
        //TIMER
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
            //Debug.Log(transform.position);
            if (Input.GetKeyUp(Controls.Up))
            {
                if (AreWeAnimating)
                {
                    ResetAllGraphics();
                    AreWeAnimating = false;
                }
                var tempPos = transform.position;
                tempPos += new Vector3(0f, MoveScale, 0f);
                if (Layout[(int)tempPos.x, (int)tempPos.y].Type != TileTypes.Wall)
                {
                    TargetPosition += new Vector3(0f, MoveScale, 0f);
                    TargetRotation = Quaternion.Euler(0, 0, 0);
                    LayoutXIndex++;
                    SM.PlayMoveSound();
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
                var tempPos = transform.position;
                tempPos += new Vector3(0f, -MoveScale, 0f);
                if (Layout[(int)tempPos.x, (int)tempPos.y].Type != TileTypes.Wall)
                {
                    TargetPosition += new Vector3(0f, -MoveScale, 0f);
                    TargetRotation = Quaternion.Euler(0, 0, 180);
                    LayoutXIndex--;
                    SM.PlayMoveSound();
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
                var tempPos = transform.position;
                tempPos += new Vector3(-MoveScale, 0f, 0f);
                if (Layout[(int)tempPos.x, (int)tempPos.y].Type != TileTypes.Wall)
                {
                    TargetPosition += new Vector3(-MoveScale, 0f, 0f);
                    TargetRotation = Quaternion.Euler(0, 0, 90);
                    LayoutYIndex--;
                    SM.PlayMoveSound();
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

                var tempPos = transform.position;
                tempPos += new Vector3(MoveScale, 0f, 0f);
                if (Layout[(int)tempPos.x, (int)tempPos.y].Type != TileTypes.Wall)
                {
                    TargetPosition += new Vector3(MoveScale, 0f, 0f);
                    TargetRotation = Quaternion.Euler(0, 0, -90);
                    LayoutYIndex++;
                    SM.PlayMoveSound();

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

            var localPos = transform.position;
            localPos += new Vector3(MoveScale, 0f, 0f);
            if (Layout[(int)localPos.x, (int)localPos.y].Type == TileTypes.Goal)
            {
                SM.PlayGoalSound();
                //Debug.LogWarning("Win");
                AreWeFinished = true;
                Confetti.SetActive(true);
                Timer.Pause();
                NextLevelTextObject.SetActive(true);
            }

            //transform.position = Vector3.MoveTowards(transform.position, TargetPosition, MovingAnimationTime * Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, RotationAnimationTime * Time.deltaTime);

        }
    }
    void LevelParser(string level)
    {
        //Divide everything up


        var row = LevelLayout.Split('\n');
        var rowIndex = row.Length-1;
        foreach (var r in row)
        {
            string[] characters = new string[r.Length];
            for (int i = 0; i < r.Length; i++)
            {
                characters[i] = r[i].ToString();
                //Debug.Log(characters[i]);
            }

            for (int i = 0; i < characters.Length; i++)
            {
                var t = new Tile();
                switch (characters[i])
                {
                    case " ":
                        t.Type = TileTypes.Open;
                        Instantiate(OpenPrefab, new Vector3(i, rowIndex, -1f), Quaternion.identity);
                        break;
                    case "X":
                        t.Type = TileTypes.Wall;
                        break;
                    case ".":
                        t.Type = TileTypes.Goal;
                        break;
                    case "!":
                        t.Type = TileTypes.Start;
                        Instantiate(OpenPrefab, new Vector3(i, rowIndex, -1f), Quaternion.identity);
                        LayoutXIndex = i;
                        LayoutYIndex = rowIndex;
                        break;
            
                    default:
                        throw new System.Exception("Default was reached");
                }
                Layout[i ,rowIndex] = t;
            }

            


            rowIndex--;
        }
        //Debug.Log("X: " + LayoutXIndex + " - Y: " + LayoutYIndex);

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
