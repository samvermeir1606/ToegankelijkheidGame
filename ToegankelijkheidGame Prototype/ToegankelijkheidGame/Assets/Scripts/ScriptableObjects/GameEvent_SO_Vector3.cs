using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class GameEvent_SO_Vector3 : ScriptableObject
{

    private List<GameEventListener_Vector3> listeners =
        new List<GameEventListener_Vector3>();

    public void Raise(Vector3 v)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(v);
    }



    public void RegisterListener(GameEventListener_Vector3 listener)
    { listeners.Add(listener); }

    public void UnregisterListener(GameEventListener_Vector3 listener)
    { listeners.Remove(listener); }
}

