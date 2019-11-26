using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Variables")]
    public float playerSpeed;
    public float moveRange;
    public float bankAmount;
    public float propSpeed;
    public AudioClip shoot;

    [Header("Player Life UI")]
    public GameObject[] healthPacks;

    [Header("Camera")]
    public Camera cam;
    public float screenShake;

    [Header("Hit")]
    public GameObject hit1;
    public GameObject hit2;
    public GameObject hit3;
    public Color hitColor;
    public Color normColor;
    public float hitTime;

    [Header("Player Links")]
    public Rigidbody rb;
    public Transform body;

    [Header("Propellors")]
    public Transform prop1;
    public Transform prop2;

    [Header("Gunfire")]
    public float fireRate;
    public GameObject bullet;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;

    float hori;
    float verti;
    bool cantShoot = false;
    AudioSource playSound;
    bool canShootSound = true;
   
    // Start is called when the script spawns
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     

        //Active game start function
        GameManager.instance.GameStart();

        //Get the audio component
        playSound = gameObject.GetComponent<AudioSource>();

        // Start the DeathCheck loop
        StartCoroutine("DeathCheck");
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal"); // Gets the horizontal input (A D Left & Right)
        

        // Creating horizontal velocity based on speed and local rotation
        Vector3 horiVel = transform.right * playerSpeed * hori;
       

        // Get the position x of the player
        float posX = transform.position.x;

        if (hori > 0 && posX < moveRange)
        {
            // Adding velocity to our player
            rb.velocity = horiVel * Time.deltaTime;
        }
        else if (hori < 0 && posX > -moveRange)
        {
            // Adding velocity to our player
            rb.velocity = horiVel * Time.deltaTime;
        }
        else
        {
            // Slow down the player
            rb.velocity *= 0.8f; // rb.velocity = rb.velocity * 0.9f;
        }

        // This will bank the player
        body.localEulerAngles = new Vector3(0, 0, -hori * bankAmount);

        // Rotate the propellors
        prop1.Rotate(new Vector3(0, propSpeed, 0));
        prop2.Rotate(new Vector3(0, -propSpeed, 0));

        // Press space to shoot and need wait to shoot
        if (Input.GetKey(KeyCode.Space) && !cantShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        // not be able to shoot
        cantShoot = true;

        // Create the bullets and spawn them on our spawn locations
        Instantiate(bullet, bulletSpawn1.position, bulletSpawn1.rotation);
        Instantiate(bullet, bulletSpawn2.position, bulletSpawn2.rotation);

        //Active sound
        StartCoroutine("ShootSound");
        // Wait for our firerate in seconds
        yield return new WaitForSeconds(fireRate);

        // The player can now shoot again
        cantShoot = false;
    }

    IEnumerator ShootSound()
    {
        if (canShootSound == true)
        {
            canShootSound = false;
            //PLAY sound // AUDIO CLIP TO AUDIO SOUCER
            playSound.clip = shoot;
            playSound.Play();
            yield return new WaitForSeconds(playSound.clip.length);
            canShootSound = true;
        }
        else
        {
            yield return null;
        }

    }
    // This will check if the player is alive
    IEnumerator DeathCheck()
    {
        // Is the GameManager.instance.playerHealth =0 or below
        while (GameManager.instance.playerHealth > 0)
        {
            // if not check again
            yield return null;
        }

        //finish the while loop and run the destroy
        Destroy(gameObject);
    }

    IEnumerator HitColor(GameObject part)
    {
        // Getting the renderer on our GameObject
        Renderer r = part.GetComponent<Renderer>();
        // Getting the material attched to that renderer
        Material mat = r.material;

        // Change the Glow/EmissionColor to another color
        mat.SetColor("_EmissionColor", hitColor);

        // Wait for half a second
        yield return new WaitForSeconds(hitTime);

        // Set the EmissionColor back
        mat.SetColor("_EmissionColor", normColor);
    }

    IEnumerator ScreenShake()
    {
        int i = 0;
        // Get Cameras original Position
        Vector3 origin = cam.transform.position;

        // Created a screenshake loop until i = 5 or more
        while(i < 5)
        {
            // Increase i + 1
            i++; // i = i + 1

            // Add a random shake amount
            float randomShakeX = Random.Range(-screenShake, screenShake);
            float randomShakeY = Random.Range(-screenShake, screenShake);

            // Shake the camera
            cam.transform.Translate(new Vector3(randomShakeX, 0, randomShakeY));

            // Wait 0.1s
            yield return new WaitForSeconds(0.05f);
        }

        // Set camera back to origin
        cam.transform.position = origin;
    }

    void PlayerHit()
    {
        StartCoroutine("HitColor", hit1);
        StartCoroutine("HitColor", hit2);
        StartCoroutine("HitColor", hit3);
        StartCoroutine("ScreenShake");
    }

    // When something enters the players collider
    private void OnTriggerEnter(Collider col)
    {
        // Does the thing we collided with have the tag "Enemy" or "EnemyBullet"
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            // destroy the enemy when hit player
            Destroy(col.gameObject);

            // Take 10 health from the player
            GameManager.instance.playerHealth = GameManager.instance.playerHealth - 10; // GameManager.instance.playerHealth -= 10;

            // Activate PlayerHit
            PlayerHit();
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            //destroy the enemy when hit player
            Destroy(col.gameObject);

            // Take 50 health from the player
            GameManager.instance.playerHealth = GameManager.instance.playerHealth - 50; // GameManager.instance.playerHealth -= 50;

            PlayerHit();
        }

        if (col.gameObject.CompareTag("Meteor"))
        {
            PlayerHit();

            // Take 100 health from the player
            GameManager.instance.playerHealth = GameManager.instance.playerHealth - 100; // GameManager.instance.playerHealth -=100;
            //destroy meteor when hit player
            Destroy(col.gameObject);
        }
    }
}
