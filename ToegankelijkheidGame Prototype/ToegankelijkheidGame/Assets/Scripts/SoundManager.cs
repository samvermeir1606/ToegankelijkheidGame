using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public bool UseMusic = false;
    public Image SoundButton;
    public Sprite SoundOnGraphic;
    public Sprite SoundOffGraphic;
    public AudioSource BotsSource;
    public AudioSource MoveSource;
    public AudioSource AchtergrondMuziekSource;
    public AudioSource GoalSource;
    public AudioClip BotsClip;
    public AudioClip MoveClip;
    public AudioClip AchtergrondMuziekClip;
    public AudioClip GoalClip;

    // Start is called before the first frame update
    void Start()
    {
        var l=GameObject.FindObjectsOfType(typeof(SoundManager));
        if (l.Length>1)
        {
            Destroy(SoundButton.gameObject.transform.parent.parent.gameObject);
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
        BotsSource.clip = BotsClip;
        MoveSource.clip = MoveClip;
        AchtergrondMuziekSource.clip = AchtergrondMuziekClip;
        GoalSource.clip = GoalClip;
        LoadData();
        PlayAchtergrondSound();
        SetGraphic();
    }
    public void ChangeUseMusic()
    {
        UseMusic = !UseMusic;
        if (!UseMusic)
        {
            AchtergrondMuziekSource.Pause();
        }
        else
        {
            AchtergrondMuziekSource.Play();
        }
        SetGraphic();
        SaveData();
    }
    public void SetGraphic()
    {
        if (UseMusic)
        {
            Debug.Log("On");
            SoundButton.sprite = SoundOnGraphic;
        }
        else
        {
            Debug.Log("Off");
            SoundButton.sprite = SoundOffGraphic;
        }
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("UseMusic"))
        {

        }
        else
        {
            SaveData();
        }
        var use=PlayerPrefs.GetInt("UseMusic");
        if (use==1)
        {
            UseMusic = true;
        }
        else
        {
            UseMusic = false;
        }
    }
    public void SaveData()
    {
        var localUse = 0;
        if (UseMusic)
        {
            localUse = 1;
        }
        PlayerPrefs.SetInt("UseMusic", localUse);
    }

    public void PlayBotsSound()
    {
        if (UseMusic)
        {
            BotsSource.Play();
        }
    }
    public void PlayMoveSound()
    {
        if (UseMusic)
        {
            MoveSource.Play();
        }
    }
    public void PlayAchtergrondSound()
    {
        if (UseMusic)
        {
            AchtergrondMuziekSource.Play();
        }
    }
    public void PlayGoalSound()
    {
        if (UseMusic)
        {
            GoalSource.Play();
        }
    }
}
