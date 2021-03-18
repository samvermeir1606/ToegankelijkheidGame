using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class GuessTheWordManager : MonoBehaviour
{
    public List<LetterAsset> Letters = new List<LetterAsset>();
    public List<TextMeshProUGUI> UILetters = new List<TextMeshProUGUI>();
    public const string Word = "mindset";
    public TextMeshProUGUI WrongFeedbackText;
    public float AnimationTime;
    public AnimationCurve AnimCurve;
    public GameObject Confetti;
    public GameObject MindsetWordObject;

    // Start is called before the first frame update
    void Start()
    {
        Confetti.SetActive(false);
        MindsetWordObject.SetActive(false);
        LoadData();
        SetUI();
    }
    public void SetUI()
    {
        for (int i = 0; i < Letters.Count; i++)
        {
            if (Letters[i].IsUnlocked)
            {
                UILetters[i].text = Letters[i].Letter;
            }
            else
            {
                UILetters[i].text = "?";
            }
        }
    }


    [Button]
    public void LoadData()
    {

        for (int i = 0; i < Letters.Count; i++)
        {
            Letters[i] = JsonUtility.FromJson<LetterAsset>(PlayerPrefs.GetString(Letters[i].Letter));
        }
    
        var UnlockedCount = 0;
        for (int i = 0; i < Letters.Count; i++)
        {
            if (Letters[i].IsUnlocked)
            {
                UnlockedCount++;
            }
        }
        Debug.Log(Letters.Count + " letters Loaded from playerprefs. " + UnlockedCount + " already unlocked.");
    }

    public void CheckWord(string s)
    {
        var lowerWord=s.ToLower();
        if (lowerWord == Word)
        {
            Debug.Log("you guessed the word!!");
            Confetti.SetActive(true);
            MindsetWordObject.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong anwser");
            StartCoroutine(AnimateWrongFeedback());
        }
    }

    private IEnumerator AnimateWrongFeedback()
    {
        var t = 0.0f;

        while (t < AnimationTime)
        {
            WrongFeedbackText.color = new Color(WrongFeedbackText.color.r, WrongFeedbackText.color.g, WrongFeedbackText.color.b,AnimCurve.Evaluate(t / AnimationTime));
            t += Time.deltaTime;
            yield return null;
        }
        //WrongFeedbackText.color = new Color(WrongFeedbackText.color.r, WrongFeedbackText.color.g, WrongFeedbackText.color.b,0.0f);
    }
}
