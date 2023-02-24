using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Bullet.instance.aliveTime += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        ScoreManagement.instance.CoinsText.text = ScoreManagement.instance.Coins.ToString();
        ScoreManagement.instance.ScrapText.text = ScoreManagement.instance.Scrap.ToString();
    }
}
