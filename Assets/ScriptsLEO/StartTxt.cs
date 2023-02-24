using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTxt : MonoBehaviour
{
    //Two gameobjects for texts - Leo N
    public GameObject StartText;
    public GameObject ObjectiveText;

    //variable to see if the game has started or not - Leo N
    public bool GameStarted = false;


    void Start()
    {
        GameStarted = false;
        Time.timeScale = 0; //Stops the game and pausing everything - Leo N
        ObjectiveText.SetActive(false); // The objectiveText is turned off and set unactive - Leo N
    }

    // Update is called once per frame
    void Update()
    {
        //If Space button is pressed and the game hasn't started then game started variable is set to true and the Starttext is turned off, the game wil unpause and the "Objective" couroutine is started - Leo N
        if(Input.GetKeyDown(KeyCode.Space) && GameStarted == false)
        {
            GameStarted = true;
            StartText.SetActive(false);
            Time.timeScale = 1;
            StartCoroutine(Objective());
        }
    }

    public IEnumerator Objective() //When called for the objective text will be set active for x amount of seconds and then turned off - Leo N
    {
        ObjectiveText.SetActive(true);
        yield return new WaitForSeconds(5);
        ObjectiveText.SetActive(false);
    }

}
