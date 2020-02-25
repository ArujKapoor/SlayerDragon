using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{   
	public Vector3 fireBallOffset;

	private bool isShooting;
	private Vector3 offset;
    private Vector3 screenPoint;
	public int fireBallLayer;
	public GameObject fireBallPrefab;
    public float dragonHeight;
    public float dragonWidth;
	public float fireDelay;
	float cooldownTimer;
	float screenRatio = (float)Screen.width / (float)Screen.height;
	
	void Start()
	{
		isShooting = true;
	}
	void Update()
	{
		Shoot();
	}
	void Shoot()
	{
		if(isShooting)
		{
			cooldownTimer -= Time.deltaTime;

			if(cooldownTimer <= 0) 
			{
				// SHOOT!
				cooldownTimer = fireDelay;

				GameObject fireBall = (GameObject)Instantiate(fireBallPrefab, transform.position, Quaternion.identity);
				fireBall.layer = fireBallLayer;
			}
		}
	}
	void OnMouseDown()
	{
        offset = transform.parent.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		isShooting = false;
    }

	void OnMouseUp()
	{
		isShooting = true;
	}

    void OnMouseDrag()
	{
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z) + offset;
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        if(curPosition.y+dragonHeight > Camera.main.orthographicSize) {
			curPosition.y = Camera.main.orthographicSize - dragonHeight;
		}
		if(curPosition.y-dragonHeight < -Camera.main.orthographicSize) {
			curPosition.y = -Camera.main.orthographicSize + dragonHeight;
		}

		// Now calculate the orthographic width based on the screen ratio
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		if(curPosition.x+dragonWidth > widthOrtho) {
			curPosition.x = widthOrtho - dragonWidth;
		}
		if(curPosition.x-dragonWidth < -widthOrtho) {
			curPosition.x = -widthOrtho + dragonWidth;
		}
        
        transform.parent.position = curPosition;
    }

}
