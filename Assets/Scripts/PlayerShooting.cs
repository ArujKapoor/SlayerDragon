using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Vector3 fireBallOffset;

	public GameObject fireBallPrefab;
	public int fireBallLayer;

	public float fireDelay;
	float cooldownTimer;

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if(cooldownTimer <= 0) {
			// SHOOT!
			cooldownTimer = fireDelay;

			GameObject fireBall = (GameObject)Instantiate(fireBallPrefab, transform.position + fireBallOffset, Quaternion.identity);
			fireBall.layer = fireBallLayer;
		}
	}
}
