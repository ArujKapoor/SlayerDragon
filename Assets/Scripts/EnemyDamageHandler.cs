using UnityEngine;
using System.Collections;

public class EnemyDamageHandler : MonoBehaviour {


	private int damage;
	void Start() {

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == 8)
        {
		    damage = other.gameObject.GetComponent<PlayerStats>().collisionDamage;
        }
        else if(other.gameObject.layer == 10)
        {
            damage = other.gameObject.GetComponent<BulletHandler>().collisionDamge;
        }
		gameObject.GetComponent<EnemyStats>().health -= damage;
	}

	void Update() {
		if(gameObject.GetComponent<EnemyStats>().health <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy(gameObject);
	}

}
