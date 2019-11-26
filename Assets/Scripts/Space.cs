using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public float spaceSpeed;
    public MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spaceSpeed -= 0.05f;

        mr.material.mainTextureOffset = new Vector2(0, spaceSpeed);
    }
}
