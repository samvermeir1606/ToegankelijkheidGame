using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    Transform l;
    public AnimationCurve PulseCurve;
    float startingIntensity;
    public float Offset = 3;
    public float speed = 2;
    public Vector3 Axis=Vector3.up;
    public float Intensity;
    private Vector3 StartingPos;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Transform>();
        StartingPos = l.position;
    }

    // Update is called once per frame
    void Update()
    {
        l.position = StartingPos+new Vector3(Axis.x*(Offset + (Mathf.Sin(Time.time * speed) * Intensity)), Axis.y * (Offset * Intensity + (Mathf.Sin(Time.time * speed) * Intensity)), Axis.z * (Offset + (Mathf.Sin(Time.time * speed) * Intensity)));
    }
}
