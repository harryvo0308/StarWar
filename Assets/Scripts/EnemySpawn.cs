using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject meteor1;
    public GameObject meteor2;

    public GameObject item;

    public float moveRange;

    bool gameover = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        // While the game is still playing
        while(!gameover)
        {
            // Get a random between minimum and maximum range
            float spawnPos = Random.Range(-moveRange, moveRange);
            int spawnRate = Random.Range(1, 5);

           if(spawnRate == 1)
           {
                 // Create the enemy
                Instantiate(enemy1, new Vector3(spawnPos, 0, transform.position.z), transform.rotation);
                // Create the Meteor 1
                Instantiate(meteor1, new Vector3(spawnPos, 0, transform.position.z), meteor1.transform.rotation);
                // Create the enemy

           }
               
            else if (spawnRate == 2)
            {
                 Instantiate(enemy2, new Vector3(spawnPos, 0, transform.position.z), transform.rotation);
                 // Create the Meteor 2
                Instantiate(meteor2, new Vector3(spawnPos, 0, transform.position.z), meteor2.transform.rotation);
            }
            else if (spawnRate == 3)
            {
                 Instantiate(item, new Vector3(spawnPos, 0, transform.position.z), item.transform.rotation);
            }
               
            
           

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnRate);
           
        }
    
    }
    
}
