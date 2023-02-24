using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public void Restart() // loads the scene where you play when you press the restart button - Elias
    {
        SceneManager.LoadScene("TestScene");
    }
    public void MainMenu() // loadsthe MainMenu scene when the button is pressed - Elias
    {
        SceneManager.LoadScene("MainMenu");
    }
}
