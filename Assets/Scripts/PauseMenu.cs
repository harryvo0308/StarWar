using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool GameIsPaused = false; //Not active when start

 
    // Update is called once per frame
    void Update()
    {
        //Key down to show out PAUSE MENU UI
        if (Input.GetKey(KeyCode.P))
        {
            Pause();
        }
       else if (Input.GetKey(KeyCode.R))
            {
                Resume();
            }
             
    }
    //Pause functions
    void Pause()
    {
        //Frozen time when showing out PASUE MENU
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);


    }
    //Resume functions
   public void Resume()
    {
        //Return to normal time when close PAUSE MENU
        Time.timeScale = 1;

        pauseMenuUI.SetActive(false);
       
    }
   

    //Load Scene MENU in scene 0
    public void LoadMenu() 
    {
        SceneManager.LoadScene(0);
     }

    //Quit game
    public void Quitgame()
    {
        //Show out game quited on editor mode
        Debug.Log("Quit");
        Application.Quit();
    }
}
