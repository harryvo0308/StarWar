using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float playerHealth;

    public GameObject[] healthPacks;

    public float score;

    public bool gameOver = false;
    // Awake before the first frame update
    void Awake()
    {
        //if the gameObject doesnt exist
        if (instance == null)
        {
            //set the instance of this to this gameobject
            instance = this;

        }
        //if the gameobject already exists
        else if (instance != this)
        {
            //destroy the new one
            Destroy(gameObject);
        }

        //Do not destroy
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(gameOver == true)
        {
            //Load final sence
            SceneManager.LoadScene(2);
            gameOver = false;
        }
    }

    public void GameStart()
    {
        healthPacks = GameObject.Find("Player").GetComponent<Player>().healthPacks;
        playerHealth = 300;
        //Active health check
        StartCoroutine("healthCheck");
        score = 0;

    }

    IEnumerator healthCheck()
    {
        while (playerHealth > 0)
        {
            if (playerHealth > 200)
            {
                healthPacks[0].gameObject.SetActive(true);
                healthPacks[1].gameObject.SetActive(true);
                healthPacks[2].gameObject.SetActive(true);
            }
            else if (playerHealth > 100 && playerHealth < 200)
            {
                healthPacks[0].gameObject.SetActive(true);
                healthPacks[1].gameObject.SetActive(true);
                healthPacks[2].gameObject.SetActive(false);
            }
            else if (playerHealth > 0 && playerHealth <= 100)
            {
                healthPacks[0].gameObject.SetActive(true);
                healthPacks[1].gameObject.SetActive(false);
                healthPacks[2].gameObject.SetActive(false);
            }
              yield return null;
    }
                healthPacks[0].gameObject.SetActive(false);
                healthPacks[1].gameObject.SetActive(false);
                healthPacks[2].gameObject.SetActive(false);
        gameOver = true;
}
}