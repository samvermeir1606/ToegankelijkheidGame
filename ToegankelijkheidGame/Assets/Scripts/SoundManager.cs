using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Music")]
    public Image MusicBackground;
    public Image MusicForeground;
    public Sprite MusicBackgroundOn;
    public Sprite MusicBackgroundOff;
    public Sprite MusicForegroundOn;
    public Sprite MusicForegroundOff;
    [Header("SFX")]
    public Image SFXBackground;
    public Image SFXForeground;
    public Sprite SFXBackgroundOn;
    public Sprite SFXBackgroundOff;
    public Sprite SFXForegroundOn;
    public Sprite SFXForegroundOff;

    [Header("AudioSources")]
    public AudioSource BackgroundMusic;

    public AudioSource ClickSound;
    public AudioSource FootstepSound;
    public AudioSource PickupSound;
    public AudioSource GoalReachedSound;
    public AudioSource BalloonCollectedFinishScreenSound;
    public AudioSource BalloonPopSound;
    [Header("AudioClips")]
    public AudioClip BackgroundMusic_Clip;

    public AudioClip ClickSound_Clip;
    public AudioClip FootstepSound_Clip;
    public AudioClip PickupSound_Clip;
    public AudioClip GoalReachedSound_Clip;
    public AudioClip BalloonCollectedFinishScreenSound_Clip;
    public AudioClip BalloonPopSound_Clip;
    [Header("States")]
    public bool SFXState;
    public bool MusicState;
    // Start is called before the first frame update
    void Awake()
    {
        if (BackgroundMusic_Clip!=null)
        {
            BackgroundMusic.clip = BackgroundMusic_Clip;
        }
        if (ClickSound_Clip != null)
        {
            ClickSound.clip = ClickSound_Clip;
        }
        if (FootstepSound_Clip != null)
        {
            FootstepSound.clip = FootstepSound_Clip;
        }
        if (PickupSound_Clip != null)
        {
            PickupSound.clip = PickupSound_Clip;
        }
        if (GoalReachedSound_Clip != null)
        {
            GoalReachedSound.clip = GoalReachedSound_Clip;
        }
        if (BalloonCollectedFinishScreenSound_Clip != null)
        {
            BalloonCollectedFinishScreenSound.clip = BalloonCollectedFinishScreenSound_Clip;
        }
        if (BalloonPopSound_Clip != null)
        {
            BalloonPopSound.clip = BalloonPopSound_Clip;
        }


        GetSFXState();
        GetMusicState();
        PlayBackgroundMusic();
        SetMusicVisuals();
        SetSFXVisuals();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlayClickSound();
        }
    }

    // Update is called once per frame
    public void ToggleSFX()
    {
        SFXState = !SFXState;
        if (SFXState)
        {
            PlayerPrefs.SetString("SFXState", "true");
        }
        else
        {
            PlayerPrefs.SetString("SFXState", "false");
        }
        SetSFXVisuals();
    }
    public void ToggleMusic()
    {
        MusicState = !MusicState;
        if (MusicState)
        {
            PlayerPrefs.SetString("MusicState", "true");
        }
        else
        {
            PlayerPrefs.SetString("MusicState", "false");
        }
        SetMusicVisuals();
    }
    private void GetSFXState()
    {
        if (!PlayerPrefs.HasKey("SFXState"))
        {
            PlayerPrefs.SetString("SFXState", "true");
        }
        if (PlayerPrefs.GetString("SFXState")== "true")
        {
            SFXState = true;
        }
        else
        {
            SFXState = false;
        }
    }
    private void GetMusicState()
    {
        if (!PlayerPrefs.HasKey("MusicState"))
        {
            PlayerPrefs.SetString("MusicState", "true");
        }
        if (PlayerPrefs.GetString("MusicState") == "true")
        {
            MusicState = true;
        }
        else
        {
            MusicState = false;
        }
    }
    public void PlayClickSound()
    {
        if (SFXState)
        {
            ClickSound.Play();
        }
    }
    public void StopClickSound()
    {
        ClickSound.Pause();
    }
    public void PlayBackgroundMusic()
    {
        if (MusicState)
        {
            BackgroundMusic.Play();
        }
    }
    public void StopBackgroundMusic()
    {
        BackgroundMusic.Pause();
    }
    public void PlayFootstepSound()
    {
        if (SFXState)
        {
            FootstepSound.Play();
        }
    }
    public void StopFootstepSound()
    {
        FootstepSound.Pause();
    }
    public void PlayPickupSound()
    {
        if (SFXState)
        {
            PickupSound.Play();
        }
    }
    public void StopPickupSound()
    {
        PickupSound.Pause();
    }
    public void PlayGoalReachedSound()
    {
        if (SFXState)
        {
            GoalReachedSound.Play();
        }
    }
    public void StopGoalReachedSound()
    {
        GoalReachedSound.Pause();
    }
    public void PlayBalloonCollectedFinishScreenSound()
    {
        if (SFXState)
        {
            BalloonCollectedFinishScreenSound.Play();
        }
    }
    public void StopBalloonCollectedFinishScreenSound()
    {
        BalloonCollectedFinishScreenSound.Pause();
    }
    public void PlayBalloonPopSound()
    {
        if (SFXState)
        {
            BalloonPopSound.Play();
        }
    }
    public void StopBalloonPopSound()
    {
        BalloonPopSound.Pause();
    }


    public void SetMusicVisuals()
    {
        if (MusicState)
        {
            MusicBackground.sprite = MusicBackgroundOn;
            MusicForeground.sprite = MusicForegroundOn;
        }
        else
        {
            MusicBackground.sprite = MusicBackgroundOff;
            MusicForeground.sprite = MusicForegroundOff;
        }
    }
    public void SetSFXVisuals()
    {
        if (SFXState)
        {
            SFXBackground.sprite = SFXBackgroundOn;
            SFXForeground.sprite = SFXForegroundOn;
        }
        else
        {
            SFXBackground.sprite = SFXBackgroundOff;
            SFXForeground.sprite = SFXForegroundOff;
        }
    }
}


//background music
//Click sound
//voetstap sound
//pickup sound
//Goal reached sound
//letter placed sound
//letter picked up sound
//word guessed sound