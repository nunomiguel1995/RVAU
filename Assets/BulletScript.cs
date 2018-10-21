using UnityEngine;

public class BulletScript : MonoBehaviour {

    public GameObject BulletEmitter;
    public GameObject Bullet;
    public float BulletForce;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                GameObject temp_bullet;
                temp_bullet = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
                temp_bullet.GetComponent<Renderer>().material.color = Color.yellow;
                temp_bullet.transform.Rotate(Vector3.left * 90);

                Rigidbody temp_rigidBody;
                temp_rigidBody = temp_bullet.GetComponent<Rigidbody>();
                temp_rigidBody.AddForce(transform.right * BulletForce);

                Destroy(temp_bullet, 5f);
            }
        }

	}
}
