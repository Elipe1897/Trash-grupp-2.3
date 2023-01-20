using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shooting.instace.DMG += 1;
        ScoreManagement.instance.Coins += 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Damage()
    {
        if (ScoreManagement.instance.Coins >= 10)
        {
            Shooting.instace.DMG += 1;
            ScoreManagement.instance.Coins -= 10;

        }
    }
}
