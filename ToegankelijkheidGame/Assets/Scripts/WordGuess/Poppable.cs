using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Poppable : MonoBehaviour,IPointerClickHandler
{
    public GameObject LetterToShow;
    public GameObject PopParticleEffect;
    public Transform Parent;
    public SoundManager SM;
    public void OnPointerClick(PointerEventData eventData)
    {
        Pop();
    }

    public void Pop()
    {
        if (PopParticleEffect!=null)
        {
            var GO = Instantiate(PopParticleEffect, transform.position, transform.rotation, Parent);
            Debug.Log("Instantiated!");
            Destroy(GO, .07f);
        }
        SM.PlayBalloonPopSound();
        LetterToShow.SetActive(true);
        Destroy(gameObject);
    }
}
