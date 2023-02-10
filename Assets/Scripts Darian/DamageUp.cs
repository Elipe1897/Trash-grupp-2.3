using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shooting.instance.DMG += 1; // instancar variabeln DMG och lägger till 1 på värdet - Darian 
        ScoreManagement.instance.Coins += 1; // instancar variabeln Coins och lägger till 1 på värdet - Darian
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Damage()
    {
        if (ScoreManagement.instance.Coins >= 10) //om coins är större eller lika med 10, så går DMG upp med 1 och coins går ned med 10 - Darian
        {
            Shooting.instance.DMG += 1;
            ScoreManagement.instance.Coins -= 10;
            print("Upgrade!");
            ScoreManagement.instance.CoinsText.text = ScoreManagement.instance.Coins.ToString();
            ScoreManagement.instance.ScrapText.text = ScoreManagement.instance.Scrap.ToString();
        }
    }
}
