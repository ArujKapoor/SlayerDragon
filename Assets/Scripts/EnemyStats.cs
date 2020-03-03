using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public int collisionDamage;
    public float rateofFire;
    public int bulletDamage = 0;
    public int score = 0;
    private string enemyTag;
    // Start is called before the first frame update
    void Start()
    {
        enemyTag = gameObject.tag;

        switch (enemyTag)
        {
            case "Ninja":
                health = 100;
                collisionDamage = 50;
                rateofFire = 1f;
                bulletDamage = 50;
                score = 10;
                break;

            case "Ghost1":
                health = 50;
                collisionDamage = 100;
                rateofFire = 1f;
                score = 30;
                break;

            case "Eagle":
                health = 30;
                collisionDamage = 50;
                rateofFire = 0f;
                score = 20;
                break;

            case "Snake":
                health = 40;
                collisionDamage = 50;
                rateofFire = 0f;
                score = 20;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
