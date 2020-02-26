using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GameObject enemy;
    public int health;
    public int playerDamage;
    public float rateofFire;
    public string enemyTag;
    // Start is called before the first frame update
    void Start()
    {
        enemyTag = enemy.tag;

        switch (enemyTag)
        {
            case "Ninja":
                health = 100;
                playerDamage = 50;
                rateofFire = 1f;
                break;

            case "Ghost1":
                health = 50;
                playerDamage = 100;
                rateofFire = 1f;
                break;

            case "Eagle":
                health = 30;
                playerDamage = 50;
                rateofFire = 0f;
                break;

            case "Snake":
                health = 40;
                playerDamage = 50;
                rateofFire = 0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
