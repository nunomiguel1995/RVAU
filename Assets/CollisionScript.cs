using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {
    //Enemy prefab
    public GameObject enemy;
    //Bullet prefab
    public GameObject bullet;
    //Scoreboard
    public Text scoreboard;

    // Use this for initialization
    void Start() {
        scoreboard = GameObject.Find("Scoreboard").GetComponent<Text>();
    }

    void Update()
    {

    }

    //If bullet collides with enemy gives points to player, destroying both enemy and bullet
    void OnCollisionEnter(Collision collisionInfo)
    {
        //When changing difficulty, sometimes the enemies collide with each other, resulting in "fake" points.
        //To fix this, just check if the object tags are different

        if(collisionInfo.gameObject.tag != enemy.tag)
        {
            if (collisionInfo.gameObject.tag == "Bullet")
            {
                Destroy(enemy);
                Destroy(collisionInfo.gameObject);

                scoreboard.text = (int.Parse(scoreboard.text) + 10).ToString();
            }
            else if(collisionInfo.gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Floor").GetComponent<GameLogic>().reduceCannonHealth();

                Destroy(enemy);

                if (GameObject.FindGameObjectWithTag("Floor").GetComponent<GameLogic>().getCannonHealth() == 0)
                {
                    GameObject.Find("GameStateLabel").GetComponent<Text>().text = "You lose!";
                    GameObject.FindGameObjectWithTag("Floor").GetComponent<EnemySpawner>().enabled = false;
                }
            }
        }
    }

}
