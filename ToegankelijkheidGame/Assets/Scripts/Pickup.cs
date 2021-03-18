using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Pickup : MonoBehaviour
{
    BoxCollider TriggerArea;
    public GameEvent_ScriptableObject OnPickupTouchedEvent;
    public SoundManager SM;
    // Start is called before the first frame update
    void Start()
    {
        TriggerArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Pickup");
            SM.PlayPickupSound();
            OnPickupTouchedEvent.Raise();
            if (!PlayerPrefs.HasKey("BalloonsEarned"))
            {
                PlayerPrefs.SetInt("BalloonsEarned", 0);

            }
            PlayerPrefs.SetInt("BalloonsEarned", PlayerPrefs.GetInt("BalloonsEarned") + 1);
            Debug.Log("PlayerPrefs BalloonsEarned Set to:" + PlayerPrefs.GetInt("BalloonsEarned"));
            Destroy(gameObject);
        }
    }
}
