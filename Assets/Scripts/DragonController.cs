using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{   
	public Vector3 fireBallOffset;

	private bool isShooting;
	private Vector3 offset;
    private Vector3 screenPoint;
	private Transform shootEnemy;
	public int fireBallLayer;
	public GameObject fireBallPrefab;
    public float dragonHeight;
    public float dragonWidth;
	public float fireDelay;
	float cooldownTimer;
	float screenRatio = (float)Screen.width / (float)Screen.height;
	
	void Start()
	{
		FindClosestEnemy();
		isShooting = true;
	}
	void Update()
	{
		FindClosestEnemy();
		if (shootEnemy)
		{
			if(isShooting)
			{
				Shoot();
			}
		}
		
	}
	void Shoot()
	{
		cooldownTimer -= Time.deltaTime;

		if(cooldownTimer <= 0) 
		{
			cooldownTimer = fireDelay;

			GameObject fireBall = (GameObject)Instantiate(fireBallPrefab, transform.parent.position, transform.parent.rotation);
			fireBall.layer = fireBallLayer;
			fireBall.GetComponent<BulletHandler>().collisionDamge = gameObject.GetComponent<PlayerStats>().bulletDamage;
		}
	}
	void OnMouseDown()
	{
        offset = transform.parent.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		isShooting = false;
    }

	void OnMouseUp()
	{
		FindClosestEnemy();
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

	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		EnemyStats closestEnemy = null;
		EnemyStats[] allEnemies = GameObject.FindObjectsOfType<EnemyStats>();

		foreach (EnemyStats currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}
		if(closestEnemy)
		{
			shootEnemy = closestEnemy.transform;
			RotateToEnemy();
		}
		
	}

	void RotateToEnemy()
	{
		Vector3 direction = (shootEnemy.position - transform.parent.position).normalized;
		float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}
}
