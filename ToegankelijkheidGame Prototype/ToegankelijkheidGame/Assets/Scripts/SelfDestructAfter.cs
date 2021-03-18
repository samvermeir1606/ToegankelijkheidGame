using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructAfter : MonoBehaviour
{
    public float DestroyTime=3.0f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
