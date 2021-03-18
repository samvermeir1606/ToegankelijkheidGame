using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float Speed;
    public float InBetweenWaitTime;
    public float InitialWaitTime;
    public Vector3 TargetPosition;
    private bool Waiting = true;
    private bool OffsetWaiting = true;
    private float CurrentTime;
    private float CurrentOffsetTimer;
    private Vector3 StartingPos;

    // Start is called before the first frame update
    void Start()
    {
        Waiting = true;
        CurrentTime = 0;
        StartingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (OffsetWaiting)
        {
            CurrentOffsetTimer += Time.deltaTime;
            if (CurrentOffsetTimer >= InitialWaitTime)
            {
                OffsetWaiting = false;
                CurrentOffsetTimer = 0.0f;
                Waiting = false;
            }
        }
        else
        {
            if (Waiting)
            {
                CurrentTime += Time.deltaTime;
                if (CurrentTime >= InBetweenWaitTime)
                {
                    Waiting = false;
                    CurrentTime = 0.0f;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
                if (transform.position == TargetPosition)
                {
                    Waiting = true;
                    transform.position = StartingPos;
                }
            }
        }
        
    }
}
