using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public void Restart()
    {
        SceneManager.LoadScene("Movement test");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
