using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetrorRotation : MonoBehaviour
{
    Rigidbody rigidbody;
    public float tumble;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
          rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
  


    
}
