using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem instance;

    public float spawnInterval; //Variable for a number thats called SpawnInterval which is the time between the waves spawning - Leo N & S

    //Variblels for the diffrents waves - Leo N
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject WaveBoss;


    public int EnemiesAlive; //Variable that keeps track of how many Enemies are currently alive, so that we can show the player on the screen - Leo N & S

    void Start()
    {
        instance = this;
        StartCoroutine(SpawnWaves1()); //Starts the Coroutine "SpawnWaves1" Which starts off the waves when the game has started - Leo N & S
    }

    IEnumerator SpawnWaves1() //Starts off a wave after waiting for the seconds that is set by the variable "SpawnInterval" which in this case is 30 - Leo N & S
                              //The code sets the gameobjects / waves active and activates the enemies in the game - Leo N & S
                              //also adds x amount of enemies in the EnemiesAlive variable - Leo N & S
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

    public void EnemyKilled() //A function that removes x amount of enemies when called in this or other scripts - Leo N & S
    {
        EnemiesAlive--;
    }
}
