using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

[System.Serializable]
public struct LetterAsset
{
    public string Letter;
    public bool IsUnlocked;
}
public class WordManager : MonoBehaviour
{
    public List<LetterAsset> Letters = new List<LetterAsset>();
    public List<TextMeshProUGUI> UILetters = new List<TextMeshProUGUI>();
    public GameObject FloatingLetterPrefab;
    public GameObject LetterArrivedParticleSystem;
    public bool IsFirstLevel = false;

    private void Start()
    {
        if (Letters.Count!=UILetters.Count)
        {
            throw new System.Exception("Lists not the same length!");
        }
        LoadData();
        SetLetterUI();
        
    }

    [Button]
    public void UnlockNextLetter(Vector3 v)
    {
        var localLetter = Letters.Find((x) => { return x.IsUnlocked == false; });
        Debug.Log(localLetter.Letter);
        if (localLetter.Letter != null)
        {


            int index = 0;
            index = Letters.FindIndex(x => x.Letter == localLetter.Letter);
            localLetter.IsUnlocked = true;
            Letters[index] = localLetter;
            SpawnFloatingLetterprefab(v,UILetters[index].transform.position,Letters[index].Letter) ;
            SaveData();
        }
    }
    public void SetLetterUI()
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

    public void SpawnFloatingLetterprefab(Vector3 pos,Vector3 Dest,string letter)
    {
        var GO=Instantiate(FloatingLetterPrefab, new Vector3(pos.x, pos.y, -2.0f), Quaternion.identity);
        var comp = GO.GetComponent<GoToDestination>();
        comp.Target = Dest;
        comp.WM = this;
        comp.ArrivedParticleSystem = LetterArrivedParticleSystem;
        var compText = GO.GetComponent<TextMeshPro>();
        compText.text = letter;
    }

    [Button]
    public void SaveData()
    {
        for (int i = 0; i < Letters.Count; i++)
        {
            PlayerPrefs.SetString(Letters[i].Letter, JsonUtility.ToJson(Letters[i]));
        }

        var UnlockedCount = 0;
        for (int i = 0; i < Letters.Count; i++)
        {
            if (Letters[i].IsUnlocked)
            {
                UnlockedCount++;
            }
        }
        Debug.Log(Letters.Count + " letters saved to playerprefs. "+ UnlockedCount+" already unlocked.");
        
    }

    [Button]
    public void LoadData()
    {
        if (IsFirstLevel)
        {
            PlayerPrefs.DeleteAll();
            SaveData();
        }
        else
        {
            for (int i = 0; i < Letters.Count; i++)
            {
                if (!PlayerPrefs.HasKey(Letters[i].Letter))
                {
                    Debug.LogError(Letters[i].Letter + "Had no playerprefs value");
                }
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

    }

}
