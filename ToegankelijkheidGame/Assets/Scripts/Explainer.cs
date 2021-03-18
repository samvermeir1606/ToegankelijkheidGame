using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explainer : MonoBehaviour
{
    public string NextLevelName;
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(NextLevelName);
    }
}
