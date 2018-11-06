using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private float spawnTimer;
    private List<GameObject> spawns = new List<GameObject>();
    public bool activeSpawner;

    void Start()
    {}

    //Spawns enemies
    void Spawn()
    {
        if (activeSpawner)
        {
            if (Time.time > spawnTimer)
            {
                spawnTimer = Time.time + spawnTime;
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                GameObject spawn = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawns.Add(spawn);
                Destroy(spawn, 3.0f);
            }
        }
    }

    // Updates enemies position
    void Update()
    {
        if (activeSpawner)
        {
            foreach (GameObject g in spawns)
            {
                if (g != null)
                    g.transform.position += new Vector3(0.005f, 0, 0);
            }
        }
    }

    // Stops spawner momentarily while deleting every enemy
    public void ResetGame()
    {
        CancelInvoke("Spawn");
        foreach(GameObject g in spawns)
        {
            DestroyImmediate(g);
        }
        activeSpawner = true;
    }

    // Starts the game
    public void StartGame()
    {
        InvokeRepeating("Spawn", 1, spawnTime);
        activeSpawner = true;
    }

    // Stops the game
    public void StopGame()
    {
        CancelInvoke("Spawn");
        activeSpawner = false;
    }
}
