using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener_Vector3 : MonoBehaviour
{
    public GameEvent_SO_Vector3 Event;
    public Vector3Event Response;

    private void OnEnable()
    {
        if (this == null)
        {
            Debug.Log("99999999999999999999999999");
        }
        Event.RegisterListener(this);
    }




    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(Vector3 v)
    { Response.Invoke(v); }
}
