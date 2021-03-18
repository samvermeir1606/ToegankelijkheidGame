using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSpot : MonoBehaviour,IDropHandler
{
    public string LetterToRecieve;
    public GameEvent_ScriptableObject OnLetterCorrectlyPlaced;
    public void OnDrop(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        if (eventData.pointerDrag!=null)
        {
            var comp = eventData.pointerDrag.GetComponent<DragDrop>();
            if (comp.LetterToRepresent==LetterToRecieve)
            {
                //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition;
                comp.LockLetter();
                OnLetterCorrectlyPlaced.Raise();
            }
            else
            {
                comp.SendBackToOrig();
            }
        }
    }
}
