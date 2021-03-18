using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
using TMPro;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(BoxCollider))]
public class EndLevelManager : MonoBehaviour
{
    [Header("General")]
    //public GameObject LevelCompletedUI;
    public SoundManager SM;
    public CharacterAnimator CA;
    public CharacterKeyboardInput CKI;
    public string NextLevelName;
    public float CanvasDarkAnimationTime;
    public TextMeshProUGUI AantalBalonnenText;
    public string AantalBallonnenBeschrijving = "Ballonnen: ";
    [Header("UI")]
    public TextMeshProUGUI AantalVerzameldeBallonnen;
    public string MaxAantalVerzameldeBallonnen = "/2";
    public Animator FinishScreenAnimator;
    public CanvasGroup DarkBackgroundGroup;
    [Header("Aantal Balloons")]
    public float WaitTimeBetweenPlus = .2f;
    private int AmountOfCollectedBalloons = 0;
    public AnimationCurve ScaleUp;
    public AnimationCurve BalloonScaleUp;
    public List<GameObject> CollectedBalloonsPlaceholders = new List<GameObject>();

    public void Awake()
    {
        DarkBackgroundGroup.gameObject.SetActive(false);
        AantalBalonnenText.text = AantalBallonnenBeschrijving + AmountOfCollectedBalloons + MaxAantalVerzameldeBallonnen;
    }


    public void GoToNextLevel()
    {
        SceneManager.LoadScene(NextLevelName);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("End Touched");
            //LevelCompletedUI.SetActive(true);
            SM.PlayGoalReachedSound();
            CA.CanMove = false;
            CKI.CanMove = false;
            StartCoroutine(AnimateFinishScreenAnders());
        }
    }
    IEnumerator AnimateFinishScreen()
    {
        FinishScreenAnimator.gameObject.SetActive(false);
        DarkBackgroundGroup.gameObject.SetActive(true);
        Debug.Log("111 here");
        var LocalTime = 0.0f;

        while (LocalTime< CanvasDarkAnimationTime)
        {
            LocalTime += Time.deltaTime;
            DarkBackgroundGroup.alpha = Mathf.Lerp(0.0f, 1.0f, LocalTime / CanvasDarkAnimationTime);
            Debug.Log("here");
            yield return null;
        }

        DarkBackgroundGroup.alpha = 1.0f;
        FinishScreenAnimator.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < AmountOfCollectedBalloons; i++)
        {
            Debug.Log(" 2222 here");
            //PLAY SOUND
            var LocalScaleTime = 0.0f;
            bool TextUpdated = false;
            while (LocalScaleTime < WaitTimeBetweenPlus)
            {
                LocalScaleTime += Time.deltaTime;
                AantalVerzameldeBallonnen.gameObject.transform.localScale = new Vector3(ScaleUp.Evaluate(LocalScaleTime / WaitTimeBetweenPlus), ScaleUp.Evaluate(LocalScaleTime / WaitTimeBetweenPlus), ScaleUp.Evaluate(LocalScaleTime / WaitTimeBetweenPlus));
                if ((LocalScaleTime / WaitTimeBetweenPlus)>.5f)
                {
                    if (!TextUpdated)
                    {
                        AantalVerzameldeBallonnen.text = (i + 1) + MaxAantalVerzameldeBallonnen;
                        TextUpdated = true;
                    }
                }

                yield return null;
            }

            yield return new WaitForSeconds(WaitTimeBetweenPlus);
        }
    }
    IEnumerator AnimateFinishScreenAnders()
    {
        FinishScreenAnimator.gameObject.SetActive(false);
        DarkBackgroundGroup.gameObject.SetActive(true);
        var LocalTime = 0.0f;

        while (LocalTime < CanvasDarkAnimationTime)
        {
            LocalTime += Time.deltaTime;
            DarkBackgroundGroup.alpha = Mathf.Lerp(0.0f, 1.0f, LocalTime / CanvasDarkAnimationTime);
            Debug.Log("here");
            yield return null;
        }

        DarkBackgroundGroup.alpha = 1.0f;
        FinishScreenAnimator.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        //balloons

        //if (AmountOfCollectedBalloons!=CollectedBalloonsPlaceholders.Count)
        //{
        //    Debug.LogError("not the same");
        //}


        for (int i = 0; i < AmountOfCollectedBalloons; i++)
        {
            //PLAY SOUND
            var LocalScaleTime = 0.0f;
            while (LocalScaleTime < WaitTimeBetweenPlus)
            {
                LocalScaleTime += Time.deltaTime;
                CollectedBalloonsPlaceholders[i].gameObject.transform.localScale = new Vector3(BalloonScaleUp.Evaluate(LocalScaleTime / WaitTimeBetweenPlus), BalloonScaleUp.Evaluate(LocalScaleTime / WaitTimeBetweenPlus), BalloonScaleUp.Evaluate(LocalScaleTime / WaitTimeBetweenPlus));

                yield return null;
            }

            yield return new WaitForSeconds(WaitTimeBetweenPlus);
        }
    }
    public void AddPickup()
    {
        AmountOfCollectedBalloons++;
        AantalBalonnenText.text = AantalBallonnenBeschrijving + AmountOfCollectedBalloons + MaxAantalVerzameldeBallonnen;
    }
}
