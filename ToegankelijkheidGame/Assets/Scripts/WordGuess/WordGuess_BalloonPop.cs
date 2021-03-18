using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGuess_BalloonPop : MonoBehaviour
{
    public GameObject PopParticleEffect;
    public string HomeSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                //PLAY SOUND
                var comp = hit.transform.gameObject.GetComponent<Poppable>();
                if (comp!=null)
                {
                    comp.Pop();
                }
            }
        }
    }
    public void GoBackToHome()
    {
        SceneManager.LoadScene(HomeSceneName);
    }
}
