using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Elias 
public class Timer : MonoBehaviour
{
    public static Timer instance; // Does timer varible into an instance, instance means it can be accessed anywere in the code

    [SerializeField]
    public TMP_Text textTimer; // varible for text 

    [SerializeField]
    public TMP_Text textLeaderTime; // fastest time to text

    [SerializeField]
    private float timer = 0.0f; // Timer varible = 0 
    [SerializeField]
    public float leadertime = 0.0f; // leadertime starts at 0

    private bool isTimer = false; // sets varible isTimer = false 

    private void Start()
    {
        isTimer = true; // at start sets isTimer true
        leadertime = PlayerPrefs.GetInt("Best Time");
        //   textLeaderTime.text = "Best Time: " + leadertime.ToString() + " s";
        DisplayLeaderTime();
        
       // highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }
    private void Awake()
    {
        instance = this; // asign it self an instance 
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer) // ökar tiden varje sekund och visar the på displayn 
        {
            timer += Time.deltaTime;
            Displaytime();
        }
        if (leadertime > timer) // Looks if score is higher than highscore - Elias
        {
            PlayerPrefs.SetInt("Best Time", (int)timer);
        }
    }

    void Displaytime()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);   // if seconds > 60 then minutes becomes 1 
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Makes minutes at the left side of ":" and seconds right of the ":" 
    }
    void DisplayLeaderTime()
    {
        int minutes = Mathf.FloorToInt(leadertime / 60f);
        int seconds = Mathf.FloorToInt(leadertime - minutes * 60);   // if seconds > 60 then minutes becomes 1 
        textLeaderTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void Stoptimer()
    {
        isTimer = false;      // sets isTimer = false 
    }

    public void ResetTimer()
    {
        timer = 0.0f; // sets timer = 0 
    }

    public void PauseTime()
    {

        Time.timeScale = 0f;

    }
}
/* 
 
highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
scoreText.text = "| POINTS: " + score.ToString() + " |  ";
highscoreText.text = "| HIGHSCORE: " + highscore.ToString() + " | ";

*/