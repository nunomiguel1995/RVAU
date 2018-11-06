using UnityEngine;

public class BulletScript : MonoBehaviour {
    //GameObject from where bullets will be emitted
    public GameObject BulletEmitter;
    //Bullet prefab
    public GameObject Bullet;
    //"Speed" of bullet
    public float BulletForce;

    public bool activeShooter;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        if (activeShooter)
        {
            //For each touch on screen fire a bullet
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    GameObject temp_bullet;
                    temp_bullet = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
                    temp_bullet.GetComponent<Renderer>().material.color = Color.yellow;

                    Rigidbody temp_rigidBody;
                    temp_rigidBody = temp_bullet.GetComponent<Rigidbody>();
                    temp_rigidBody.AddForce(transform.right * BulletForce);

                    //If no collision detected, destroy prefab after 3 seconds
                    Destroy(temp_bullet, 3f);
                }
            }
        }
	}
}
