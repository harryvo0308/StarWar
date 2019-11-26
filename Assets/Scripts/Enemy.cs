using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float fireRate;

    public float lrMoveRange;

    public GameObject bullet;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;

    bool leftRight = true;
    int whichEnemy = 1;

    // Start is called before the first frame update
    void Start()
    {
        whichEnemy = Random.Range(1, 4);
        // Activate the functions 
        
        StartCoroutine("AlwaysShoot");

        if (whichEnemy == 1)
        {
            StartCoroutine("MoveLeftRight");
        } else
        {
            StartCoroutine("MoveForward");
        }
    }

    // runs every frame until game over or pause game
    IEnumerator MoveForward()
    {
        // enemy is above -10 move the enemy
        while(transform.position.z > -10)
        {
            transform.Translate(new Vector3(0, 0, enemySpeed * Time.deltaTime));

            // Reset the while loop every frame
            yield return null;
        }

        // Destroy enemy when out of frame
        Destroy(gameObject);
    }

    IEnumerator MoveLeftRight()
    {
        while(transform.position.z > 26)
        {
            transform.Translate(new Vector3(0, 0, enemySpeed * Time.deltaTime));

            yield return null;
        }

        while (true)
        {
            if (leftRight) // leftRight == true 
            {
                transform.Translate(new Vector3(enemySpeed * Time.deltaTime, 0, 0));
            }
            else if(!leftRight) // leftRight == false
            {
                transform.Translate(new Vector3(-enemySpeed * Time.deltaTime, 0, 0));
            }

            if (transform.position.x <= -lrMoveRange)
            {
                leftRight = false;
            }
            else if (transform.position.x >= lrMoveRange)
            {
                leftRight = true;
            }

            yield return null;
        }
    }

    IEnumerator AlwaysShoot()
    {
        // Always run the loop until the enemy is destroyed
        while(true)
        {
            // Create Bullets and spawn them on our spawn positions
            Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
            Instantiate(bullet, bulletSpawn2.position, bulletSpawn2.rotation);

            // wait for the fire gun cooldown
            yield return new WaitForSeconds(fireRate);
        }
    }
}
