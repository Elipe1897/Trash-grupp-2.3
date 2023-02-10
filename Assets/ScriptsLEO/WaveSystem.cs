using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem instance;

    public GameObject enemyPrefab;
    public float spawnInterval = 30f;
    public int numberOfWaves = 5;

    private int waveCounter = 0;

    public GameObject[] punkter;
    public GameObject[] alien;

    public int EnemiesAlive;
    public int rng;
    public int random;
    void Start()
    {
        instance = this;
        StartCoroutine(SpawnWaves());
    }
    public void Update()
    {
        int rng = Random.Range(0, 10);
        int random = Random.Range(0, 1);
    }

    IEnumerator SpawnWaves()
    {
        while (waveCounter < numberOfWaves)
        {
            for (int i = 0; i < waveCounter; i++)
            {
                Spawn();
            }
            waveCounter++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Spawn()
    {
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        Instantiate(alien[random], punkter[rng].transform.position, Quaternion.identity);
        EnemiesAlive += 8;
    }

    public void EnemyKilled()
    {
        EnemiesAlive--;
    }
}
