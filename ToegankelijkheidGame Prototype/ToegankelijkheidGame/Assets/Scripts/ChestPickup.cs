using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ChestPickup : MonoBehaviour
{
    public GameEvent_SO_Vector3 OnChestPickup;
    public GameObject ParticleSystemToDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Debug.Log("Found a letter ");
            OnChestPickup.Raise(transform.position);
            Instantiate(ParticleSystemToDisplay, new Vector3(transform.position.x, transform.position.y, -2.0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
