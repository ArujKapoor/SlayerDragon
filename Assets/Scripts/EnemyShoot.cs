using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float coolDownTimer;
    public float delay;
    public GameObject weaponPrefab;
    public int weaponLayer;
    // Start is called before the first frame update
    void Start()
    {
        shoot();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        
        coolDownTimer -= Time.deltaTime;

        if (coolDownTimer <= 0)
        {
            coolDownTimer = delay;
            
            GameObject shuriken = (GameObject)Instantiate(weaponPrefab, transform.position, transform.rotation);
            var rotation = Quaternion.LookRotation(transform.position) * Quaternion.Euler(0f, 0f, 10);
            //Quaternion rotation1 = Quaternion.Euler(0f, 0f, rot1 + 10);
            GameObject shuriken1 = (GameObject)Instantiate(weaponPrefab, transform.position, rotation);
            
            shuriken.layer = weaponLayer;
            shuriken1.layer = weaponLayer;
            
            shuriken.GetComponent<BulletHandler>().collisionDamge = gameObject.GetComponent<EnemyStats>().bulletDamage;
            shuriken1.GetComponent<BulletHandler>().collisionDamge = gameObject.GetComponent<EnemyStats>().bulletDamage;
            
        }
    }
}
