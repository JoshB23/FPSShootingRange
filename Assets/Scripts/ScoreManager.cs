using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText, timeText, ggText;
    public int score, targetScore;
    public float time = 3f;
    public bool playing;
    public GameObject gameOver;

    void Start()
    {
        //starts game with timescale of 0, then calls for the 3 second countdown to start
        Time.timeScale = 0;
        StartCoroutine(Countdown());
    }

    void Update()
    {

        if (score >= targetScore)
        {
            //ending game and bringing up the game over panel with the final score once the target score is reached
            playing = false;
            Time.timeScale = 0;
            gameOver.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ggText.text = (Mathf.Round(time * 100) / 100).ToString();
        }

        if (score < targetScore && playing == true)
        {
            //counting up time until target score is reached
            time += Time.deltaTime;
            timeText.text = (Mathf.Round(time * 100) / 100).ToString();
        }

        scoreText.text = score.ToString();
    }

    IEnumerator Countdown()
    {
        //sets a three second countdown before starting the game
        yield return new WaitForSecondsRealtime(1);

        if (time > 0)
        {
            //counting down time 1 second at a time
            time--;
            timeText.text = time.ToString();
            StartCoroutine(Countdown());
        }

        else
        {
            //ends countdown and starts game by setting timescale to 1
            playing = true;
            Time.timeScale = 1;
        }
    }
}
