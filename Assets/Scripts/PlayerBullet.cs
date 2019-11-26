using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BulletFly");
    }

    IEnumerator BulletFly()
    {
        while(transform.position.z < 54)
        {
            transform.Translate(new Vector3(0, 0, bulletSpeed * Time.deltaTime));

            yield return null;
        }
        // Destroy bullet when out of frame
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        //  the bullet collided with the "Enemy"
        if (col.gameObject.CompareTag("Enemy"))
        {
            //Player has +10 score for each enemy
            GameManager.instance.score += 10;
            //Destroy 
            Destroy(col.gameObject);
        }

      else if (col.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(col.gameObject);
        }
    }
}
