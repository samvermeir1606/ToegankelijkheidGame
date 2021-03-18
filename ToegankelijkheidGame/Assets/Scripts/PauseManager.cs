using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public CharacterAnimator CA;
    public CharacterKeyboardInput CKI;
    public GameObject PauseMenu;
    //[Header("Music")]
    //public Image MusicBackground;
    //public Image MusicForeground;
    //public Sprite MusicBackgroundOn;
    //public Sprite MusicBackgroundOff;
    //public Sprite MusicForegroundOn;
    //public Sprite MusicForegroundOff;
    //public bool MusicState;
    //[Header("SFX")]
    //public Image SFXBackground;
    //public Image SFXForeground;
    //public Sprite SFXBackgroundOn;
    //public Sprite SFXBackgroundOff;
    //public Sprite SFXForegroundOn;
    //public Sprite SFXForegroundOff;
    //public bool SFXState;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        //Debug.LogWarning("Check Sound States");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        CA.CanMove = false;
        CKI.CanMove = false;
        PauseMenu.SetActive(true);

    }
    public void ResumeGame()
    {
        CA.CanMove = true;
        CKI.CanMove = true;
        PauseMenu.SetActive(false);
    }
    //public void ToggleMusic()
    //{
    //    MusicState = !MusicState;
    //    SetMusicVisuals();
    //}
    //public void SetMusicVisuals()
    //{
    //    if (MusicState)
    //    {
    //        MusicBackground.sprite = MusicBackgroundOn;
    //        MusicForeground.sprite = MusicForegroundOn;
    //    }
    //    else
    //    {
    //        MusicBackground.sprite = MusicBackgroundOff;
    //        MusicForeground.sprite = MusicForegroundOff;
    //    }
    //}
    //public void SetSFXVisuals()
    //{
    //    if (SFXState)
    //    {
    //        SFXBackground.sprite = SFXBackgroundOn;
    //        SFXForeground.sprite = SFXForegroundOn;
    //    }
    //    else
    //    {
    //        SFXBackground.sprite = SFXBackgroundOff;
    //        SFXForeground.sprite = SFXForegroundOff;
    //    }
    //}
    //public void ToggleSFX()
    //{
    //    SFXState = !SFXState;
    //    SetSFXVisuals();
    //}
}
