using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WalkingSim");
    }

    public void LoadStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
