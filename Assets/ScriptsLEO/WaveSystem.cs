using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem instance;

    public float spawnInterval;

    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject WaveBoss;


    public int EnemiesAlive;

    void Start()
    {
        instance = this;
        StartCoroutine(SpawnWaves1());
    }

    IEnumerator SpawnWaves1()
    {
        yield return new WaitForSeconds(spawnInterval);
        Wave1.SetActive(true);
        EnemiesAlive += 8;
        yield return new WaitForSeconds(spawnInterval);
        Wave2.SetActive(true);
        EnemiesAlive += 8;
        yield return new WaitForSeconds(spawnInterval);
        Wave3.SetActive(true);
        EnemiesAlive += 8;
        yield return new WaitForSeconds(spawnInterval);
        WaveBoss.SetActive(true);
        EnemiesAlive += 1;
    }

    public void EnemyKilled()
    {
        EnemiesAlive--;
    }
}
