using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler
{
    public string LetterToRepresent;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool IsLocked = false;
    private Vector3 OrigPos;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        OrigPos = rectTransform.localPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

        }

        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            //throw new System.NotImplementedException();
            rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            //throw new System.NotImplementedException();
            //rectTransform.localPosition = OrigPos;
            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
    public void SendBackToOrig()
    {
        rectTransform.localPosition = OrigPos;
    }
    public void LockLetter()
    {
        IsLocked = true;
        canvasGroup.alpha = 1.0f;
    }
}
