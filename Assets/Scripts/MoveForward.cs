using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float speed = 5f;

	// Update is called once per frame
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.up * speed;
	}

}
