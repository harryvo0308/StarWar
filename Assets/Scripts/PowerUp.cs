using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    private int duration = 3;
    private float mul = 1.5f;
   public GameObject PickupEffect;

   void OnTriggerEnter (Collider other)
   {
       if(other.CompareTag("Player"))
       {
          StartCoroutine(Pickup(other));
       }
   }

   IEnumerator Pickup(Collider player)
   {
       //Effect when pick up
       Instantiate( PickupEffect, transform.position, transform.rotation);

       //Power Up for player by make it bigger
       
       player.transform.localScale *= mul ;
      

        //Hiden object before destroying
       GetComponent<MeshRenderer>().enabled = false;
       GetComponent<Collider>().enabled = false;

        //Power up will end in 4 seconds
        yield return new WaitForSeconds(duration);
       player.transform.localScale /= mul;

       Destroy(gameObject);
   }
}
