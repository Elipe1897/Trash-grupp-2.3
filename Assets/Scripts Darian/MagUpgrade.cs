using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Darian
public class MagUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()  
    {
        Shooting.instance.Ammo = 30;
        Shooting.instance.AmmoText.text = Shooting.instance.Ammo.ToString() + "/30"; //instancar/kopierar variabeln ammo och ammostringen.
    }

    // Update is called once per frame
   public void Mag()
    {
        if (ScoreManagement.instance.Coins >= 10) //om variabeln Coins är mer eller lika med tio, så tar den bort tio coins (vid klick), och ändrar max ammo till 40 och ändrar ammo texten till 40.
        {
            Shooting.instance.AmmoUpgraded = true;
            ScoreManagement.instance.Coins -= 10;
            Shooting.instance.Ammo = 40;
            print("Upgrade!");
            ScoreManagement.instance.CoinsText.text = ScoreManagement.instance.Coins.ToString(); //ändrar texten/numrena för coins och scrap
            ScoreManagement.instance.ScrapText.text = ScoreManagement.instance.Scrap.ToString();
        }
    }
}
