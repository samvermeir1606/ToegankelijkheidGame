using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGuessManager : MonoBehaviour
{
    private int numberOfLetters = 7;
    private int numbersOfLettersCorrectlyPlaced = 0;
    public string HomeSceneName;
    public GameObject ConfettiCanvas;
    public List<GameObject> AllBalloonsINORDER = new List<GameObject>();
    public void Awake()
    {
        GetTheAmountOfBalloonsEarned();
    }
    public void OnLetterCorrectlyPlaced()
    {
        numbersOfLettersCorrectlyPlaced++;
        CheckIfComplete();
    }
    public void CheckIfComplete()
    {
        if (numbersOfLettersCorrectlyPlaced== numberOfLetters)
        {
            ConfettiCanvas.SetActive(true);
            //Sound
            Debug.Log("Complete!");
        }
    }
    public void GoBackToHome()
    {
        SceneManager.LoadScene(HomeSceneName);
    }
    public void GetTheAmountOfBalloonsEarned()
    {
        var AmountEarned=PlayerPrefs.GetInt("BalloonsEarned", 999);

        if (AmountEarned == 999)
        {
            Debug.Log("Error: Not Available, Setting to default 7");
            AmountEarned = 7;
        }
        if (AmountEarned> AllBalloonsINORDER.Count)
        {
            Debug.Log("Error: too many earned");
        }

        for (int i = 0; i < AllBalloonsINORDER.Count; i++)
        {
            AllBalloonsINORDER[i].SetActive(false);
        }

        for (int i = 0; i < AmountEarned; i++)
        {
            AllBalloonsINORDER[i].SetActive(true);
        }
    }
}
