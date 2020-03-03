using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageHandler : MonoBehaviour
{
	public Text healthText;
	public Slider healthbar;

    private int maxHealth =0;
	private int damage;

	void Start() {
		healthbar.value = 100;

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

		print(gameObject.GetComponent<PlayerStats>().health);
		healthText.text = (gameObject.GetComponent<PlayerStats>().health * 100)/ maxHealth + "%";
		healthbar.value = (gameObject.GetComponent<PlayerStats>().health * 100) / maxHealth;
	}

	void Update() {
		if (maxHealth == 0)
		{
			maxHealth = gameObject.GetComponent<PlayerStats>().health;
		}

		Vector3 objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
		healthText.transform.position = new Vector3(objectPos.x, objectPos.y - 50, objectPos.z);
		healthbar.transform.position = new Vector3(objectPos.x, objectPos.y - 25, objectPos.z);
		if (gameObject.GetComponent<PlayerStats>().health <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy(transform.parent.gameObject);
	}
    
}
