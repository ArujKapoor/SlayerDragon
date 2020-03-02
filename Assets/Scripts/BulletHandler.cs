using UnityEngine;
using System.Collections;

public class BulletHandler : MonoBehaviour {

	public float speed = 5f;
	public int collisionDamge;
	public int health = 2;

	// Update is called once per frame
	void Start () {
		Debug.LogError("Shuriken Instantiated");
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}
	void OnTriggerEnter(Collider other) {
		health--;
	}

	void Update() {
		if(health <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy(gameObject);
	}


}
