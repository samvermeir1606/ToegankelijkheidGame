using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator CharacterAnimatorComponent;
    public bool CanMove=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Vertical") > 0.1f || Input.GetAxis("Horizontal") < -0.1f || Input.GetAxis("Vertical") < -0.1f)
            {
                CharacterAnimatorComponent.SetBool("IsMoving", true);

            }
            else
            {
                CharacterAnimatorComponent.SetBool("IsMoving", false);

            }
        }
        else
        {
            CharacterAnimatorComponent.SetBool("IsMoving", false);
        }

    }
}
