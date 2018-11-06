using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 1f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private float spawnTimer;
    private List<GameObject> spawns = new List<GameObject>();
    public bool activeSpawner;

    void Start()
    {}

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

    void Update()
    {
        if (!activeSpawner)
        {
            CancelInvoke("Spawn");
            foreach (GameObject g in spawns)
            {
                Destroy(g);
            }
        }
        else
        { 
            if(!IsInvoking()) InvokeRepeating("Spawn", 1, 0.5f);

            foreach (GameObject g in spawns)
            {
                if (g != null)
                    g.transform.position += new Vector3(0.005f, 0, 0);
            }
        }
    }
}
