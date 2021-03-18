using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightGlowPulse : MonoBehaviour
{
    Light l;
    public AnimationCurve PulseCurve;
    float startingIntensity;
    public float Offset = 3;
    public float speed = 2;
    public float Intensity=1;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
        startingIntensity = l.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        l.intensity = Offset+(Mathf.Sin(Time.time* speed) * Intensity);
    }
}
