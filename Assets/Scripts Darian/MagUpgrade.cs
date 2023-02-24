using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shooting.instance.Ammo = 30;
        Shooting.instance.AmmoText.text = Shooting.instance.Ammo.ToString() + "/30";
    }

    // Update is called once per frame
   public void Mag()
    {
        if (ScoreManagement.instance.Coins >= 10) //om variabeln Coins är mer eller lika med tio, så 
        {
            ScoreManagement.instance.Coins -= 10;
            Shooting.instance.Ammo = 40;
            Shooting.instance.AmmoText.text = Shooting.instance.Ammo.ToString() + "/40";
            print("Upgrade!");
        }
    }
}
