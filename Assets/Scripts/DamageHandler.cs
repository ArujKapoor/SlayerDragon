using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health;

	void Start() {

	}

	void OnTriggerEnter() {
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
