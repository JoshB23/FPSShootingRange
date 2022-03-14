using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject pauseScreen, gameOver;
    private bool paused;
    private ScoreManager sm;

    private void Start()
    {
        // accessing the scoremanager script so I can use the playing bool later
        sm = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        //input (esc) to bring up pause screen, checking if playing is true to stop pauses in countdown and making sure the game is not over
        if (Input.GetKeyDown(KeyCode.Escape) && gameOver.activeInHierarchy == false && sm.playing == true)
        {
            if (paused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //restarting timescale and hiding pause screen, hiding cursor and locking it again
        Time.timeScale = 1;
        paused = false;
        pauseScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        //setting timescale to 0 to stop gameplay, bringing up pause screen panels and making cursor visable so the menu buttons can be clicked
        Time.timeScale = 0;
        paused = true;
        pauseScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


}