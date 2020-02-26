using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{

	private int damage;

	void Start() {

	}

	void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 9)
        {
		    damage = other.gameObject.GetComponent<EnemyStats>().collisionDamage;
        }
        else if(other.gameObject.layer == 11)
        {
            damage = other.gameObject.GetComponent<BulletHandler>().collisionDamge;
        }
		gameObject.GetComponent<PlayerStats>().health -= damage;
	}

	void Update() {
		if(gameObject.GetComponent<PlayerStats>().health <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy(transform.parent.gameObject);
	}
    
}
