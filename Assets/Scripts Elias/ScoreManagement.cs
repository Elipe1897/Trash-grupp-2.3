using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance;

    public int Coins;
    public Text CoinsText;

    public int Scrap;
    public Text ScrapText;

    // varibles for Score, Trash and  and their text - Elias

    public Text MonsterText;
    public Text WaveText;
    public float WaveTimer = 30;

    public void Awake()
    {
        instance = this;  // it makes itself an instance - Elias
        //sets coin and scrap varible to zero - Elias
        Coins = 0;
        Scrap = 0;
        WaveTimer = 30;
    }
    public void Start()
    {
        // Writes out the value Coin,Scrap to text in the text varibles - Elias
        CoinsText.text = Coins.ToString();
        ScrapText.text =  Scrap.ToString();

        MonsterText.text = WaveSystem.instance.EnemiesAlive.ToString();
        WaveText.text = "Next Wave: " + WaveTimer.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        WaveTimer -= Time.deltaTime;
        MonsterText.text = WaveSystem.instance.EnemiesAlive.ToString();
        WaveText.text = "Next Wave: " + Mathf.Ceil(WaveTimer).ToString();
        


        if (WaveTimer == 0 || WaveTimer < 0)
        {
            WaveTimer += 30;
        }
    }
    public void AddPoint(int point)// Adds the set points to points in score and then writes the value of the varible out - Elias
    {
        Coins += point;
        CoinsText.text = Coins.ToString();
        Scrap -= Scrap;
        ScrapText.text = Scrap.ToString();
        Debug.Log(Coins);
        //Debug.Log(Scrap);
    }
    public void AddSCrap() // Adds 1 to the Scrap varible value and writes it out in text and then sets the TouchScrap varible in PlayerController_1 script to false - Elias
    {
        Scrap ++;
        ScrapText.text = Scrap.ToString();
        PlayerController_1.instance.TouchScrap = false;
        //Debug.Log(Scrap);
    }
    
}
