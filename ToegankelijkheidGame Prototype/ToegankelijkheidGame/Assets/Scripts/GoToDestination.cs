using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDestination : MonoBehaviour
{
    public Vector3 Target;
    public Vector3 StartPosition;
    public WordManager WM;
    public float Speed;
    public float AnimationTime;
    public GameObject ArrivedParticleSystem;
    public AnimationCurve AnimCurve;

    private void Start()
    {
        StartPosition = transform.position;
    }
    void Update()
    {
        StartCoroutine(Animate());
        //transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * Speed);
        //if (transform.position== Target)
        //{
        //    Debug.Log("We've Arrived!");
        //    Instantiate(ArrivedParticleSystem, transform.position, Quaternion.identity);
        //    WM.SetLetterUI();
        //    Destroy(gameObject);
        //
        //}
    }
    IEnumerator Animate()
    {
        var t = 0.0f;

        while (t<AnimationTime)
        {
            transform.position = Vector3.Slerp(StartPosition, Target, AnimCurve.Evaluate(t / AnimationTime));
            t += Time.deltaTime;
            yield return null;
        }
        transform.position = Target;
        Debug.Log("We've Arrived!");
        Instantiate(ArrivedParticleSystem, transform.position, Quaternion.identity);
        WM.SetLetterUI();
        Destroy(gameObject);
    }
}
