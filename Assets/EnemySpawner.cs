using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 1f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private int enemyCount = 0;
    private float spawnTimer;
    private List<GameObject> spawns = new List<GameObject>();

    void Start(){
        InvokeRepeating("Spawn", 1, 0.5f);
    }

    void Spawn()
    {
        if (enemyCount < 10)
        {
            if (Time.time > spawnTimer)
            {
                spawnTimer = Time.time + spawnTime;
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                GameObject spawn = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawns.Add(spawn);
                enemyCount++;
            }
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        foreach(GameObject g in spawns)
        {
            Debug.Log("Position " + transform.position);
            g.transform.position += new Vector3(0.005f, 0, 0);
            Debug.Log("New Position " + transform.position);
        }
    }
}
