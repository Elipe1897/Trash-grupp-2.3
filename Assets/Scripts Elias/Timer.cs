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
    public TMP_Text LeaderTime; // fastest time to text

    [SerializeField]
    private float timer = 0.0f; // Timer varible = 0 

    private bool isTimer = false; // sets varible isTimer = false 

    private void Start()
    {
        isTimer = true; // at start sets isTimer true 
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
    }

    void Displaytime()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);   // if seconds > 60 then minutes becomes 1 
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Makes minutes at the left side of ":" and seconds right of the ":" 
    }
    public void Stoptimer()
    {
        isTimer = false;      // sets isTimer = false 
    }

    public void ResetTimer()
    {
        timer = 0.0f; // sets timer = 0 
    }


}
