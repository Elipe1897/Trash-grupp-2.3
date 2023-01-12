using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance;

    public int Coins;
    public Text CoinsText;

    public int Scrap;
    public Text ScrapText;
    // varibles for Score, Trash and time and text

    public void Awake()
    {
        instance = this;  // it makes itself an instance
        //sets coin and scrap varible to zero
        Coins = 0;
        Scrap = 0;

    }
    public void Start()
    {
        CoinsText.text = " COINS: " + Coins.ToString();
        ScrapText.text = " SCRAP: " + Scrap.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Coins);
    }
    public void AddPoint(int point)// Adds the set points to points in score - Elias
    {
        Coins += point;
        CoinsText.text = " COINS: " + Coins.ToString();
    }

}
