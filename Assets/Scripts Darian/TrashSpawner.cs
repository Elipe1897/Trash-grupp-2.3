using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject Trash;

    float maxSpawnRateInSeconds = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnTrash", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnTrash()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anTrash = (GameObject)Instantiate(Trash);
        anTrash.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextTrashSpawn();
    }
    void ScheduleNextTrashSpawn()
    {
        float spawnInNSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;
        Invoke("SpawnTrash", spawnInNSeconds);
    }
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
