using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("MoveForward");
    }

    // The IEnumerator is a function that runs every frame until we say stop or tell it to run differently
    IEnumerator MoveForward()
    {
        // While the enemy is above -10 move the enemy
        while (transform.position.z > -10)
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));

            // Reset the while loop every frame
            yield return null;
        }

        // Remove the enemy from the scene
        Destroy(gameObject);
    }
}
