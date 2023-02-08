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

    public Text MonsterText;
    public Text WaveText;
    public float WaveTimer = 30;


    // varibles for Score, Trash and time and text

    public void Awake()
    {
        instance = this;  // it makes itself an instance
        //sets coin and scrap varible to zero
        Coins = 0;
        Scrap = 0;
        WaveTimer = 30;
    }
    public void Start()
    {
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
    public void AddPoint(int point)// Adds the set points to points in score - Elias
    {
        Coins += point;
        CoinsText.text = Coins.ToString();
        Scrap -= Scrap;
        ScrapText.text = Scrap.ToString();
        Debug.Log(Coins);
        Debug.Log(Scrap);
    }
    public void AddSCrap()
    {
        Scrap ++;
        ScrapText.text = Scrap.ToString();
        Debug.Log(Scrap);
    }
    
}
