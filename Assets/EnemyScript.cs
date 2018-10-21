using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public GameObject enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Enemy Collided");
        Destroy(enemy);
        Destroy(collisionInfo.gameObject);
    }

}
