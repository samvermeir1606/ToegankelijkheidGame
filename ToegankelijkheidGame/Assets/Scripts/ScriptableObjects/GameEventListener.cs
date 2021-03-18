using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    public GameEvent_ScriptableObject Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        if (this==null)
        {
            Debug.Log("99999999999999999999999999");
        }
        Event.RegisterListener(this); }




    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised()
    { Response.Invoke(); }
}