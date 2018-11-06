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

    //If bullet collides with enemy gives points to player, destroying both enemy and bullet
    void OnCollisionEnter(Collision collisionInfo)
    {
        //When changing difficulty, sometimes the enemies collide with each other, resulting in "fake" points.
        //To fix this, just check if the object tags are different
        if(collisionInfo.gameObject.tag != enemy.tag)
        {
            Destroy(enemy);
            Destroy(collisionInfo.gameObject);

            scoreboard.text = (int.Parse(scoreboard.text) + 10).ToString();
        }
    }

}
