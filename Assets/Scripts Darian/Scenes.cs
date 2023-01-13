using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenes : MonoBehaviour
{
    //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    public void NextScene()
    {
        SceneManager.LoadScene("TextScene");
    }
}
