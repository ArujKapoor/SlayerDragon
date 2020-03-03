using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDamageHandler : MonoBehaviour {

	public Text healthText;
	public Slider healthbar;
	private int maxHealth = 0;

	private int damage;
	void Start() {
		healthbar.value = 100;
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
		print(gameObject.GetComponent<EnemyStats>().health + "......" + maxHealth);
		healthText.text = (gameObject.GetComponent<EnemyStats>().health * 100) / maxHealth + "%";
		healthbar.value = (gameObject.GetComponent<EnemyStats>().health * 100) / maxHealth;
	}

	void Update() {
        if (maxHealth == 0)
		{
			maxHealth = gameObject.GetComponent<EnemyStats>().health;
		}
		Vector3 objectPos = Camera.main.WorldToScreenPoint(this.transform.position);
		healthText.transform.position = new Vector3(objectPos.x, objectPos.y + 50, objectPos.z);
		healthbar.transform.position = new Vector3(objectPos.x, objectPos.y + 25, objectPos.z);

		if (gameObject.GetComponent<EnemyStats>().health <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy(transform.parent.gameObject);
	}

}
