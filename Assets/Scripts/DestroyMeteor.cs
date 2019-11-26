using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeteor : MonoBehaviour
{
     public GameObject explosion;
    
    
  private  void OnTriggerEnter(Collider other) 
    {
       if (other.gameObject.CompareTag("PlayerBullet"))
        {
        Instantiate(explosion, transform.position, transform.rotation);
        //Player has +20 score for each Meteor
            GameManager.instance.score += 20;
        //Destroy 
        Destroy(other.gameObject);
        Destroy(gameObject);
        }
    }
}
