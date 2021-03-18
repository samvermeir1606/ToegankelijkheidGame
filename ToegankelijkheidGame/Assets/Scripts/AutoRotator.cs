using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    public Vector3 Speed;
    void Update()
    {
        transform.Rotate(Speed);
    }
}
