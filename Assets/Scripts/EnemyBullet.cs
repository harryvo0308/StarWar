using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BulletFly");
    }

    IEnumerator BulletFly()
    {
        while (transform.position.z > -10)
        {
            //bullet fly out from z (rotation)
            transform.Translate(new Vector3(0, 0, bulletSpeed * Time.deltaTime));

            yield return null;
        }

        Destroy(gameObject);
    }
}
