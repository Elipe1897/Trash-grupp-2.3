using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn instance;
    public GameObject[] punkter;
    public GameObject[] alien;
    public GameObject Boss;
    public int alienCounter;
    int moreAlien;
    int Wave1;
    int Wave2;
    int Wave3;
    int WaveBoss;
    public int killCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Wave2 = -100;
        Wave3 = -100;
        WaveBoss = -100;
        moreAlien = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (alienCounter < Wave1)
        {
            Spawn();
        }
        if (alienCounter < Wave2)
        {
            Spawn();
        }
        if (alienCounter < Wave3 && killCount >=9)
        {
            Spawn();
        }
        if (alienCounter < WaveBoss && killCount >= 19)
        {
            SpawnBoss();
        }
        if (alienCounter == Wave1)
        {
            Wave2 = 20;
            Wave1 = 0;
        }
        if (alienCounter == Wave2)
        {
            Wave3 = 35;
            Wave2 = 0;
        }
        if (alienCounter == Wave3)
        {
            WaveBoss = 36;
            Wave3 = 0;
        }
    }
    void Spawn()
    {
        int rng = Random.Range(0, 10);
        int random = Random.Range(0, 2);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        alienCounter++;
    }
    void SpawnBoss()
    {
        int rng = Random.Range(0, 10);
        int random = Random.Range(0, 3);
        Instantiate(Boss, punkter[rng].transform.position, Quaternion.identity);
        alienCounter++;
    }
}
