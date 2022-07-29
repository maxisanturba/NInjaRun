using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [Header("Game Settings")]
    //Clock
    public float clock = 0;

    //Pause Clock
    [HideInInspector] public bool isClockPaused = false;
    [SerializeField] private float pausedTimeByClockStop = 0;
    private float pauseTimer = 0;

    //Score
    [HideInInspector] public int score;
    [HideInInspector] public int finalScore;
    [SerializeField] protected int scorePerMeter = 0;
    [SerializeField] protected float timeToScore = 0;
    protected float scoreTimer = 0;

    //Pause And Gameover Comprobation
    protected bool gameIsPaused = false;
    [HideInInspector] public bool gameIsOver = false;

    //UI
    [Header("UI Elements")]
    [SerializeField] protected GameObject pausePanel = null;
    [SerializeField] protected GameObject gameOverPanel = null;
    [SerializeField] public GameObject winPanel = null;
    [SerializeField] protected GameObject clockText = null;
    [SerializeField] protected GameObject scoreText = null;
    [SerializeField] protected GameObject finalScoreText = null;

    private void Update()
    {
        GameActive();
        GameInactive();

        PauseAndGameOver();
        if (isClockPaused) PauseClockOfDeath();

        Scoring();
        ClockOfDeath();
    }

    /* Methods for Pause and Gameover */
    public void GameActive()
    {
        if (!gameIsOver || !gameIsPaused)
        Time.timeScale = 1f;
    }    
    public void GameInactive()
    {
        if (gameIsOver || gameIsPaused)
        Time.timeScale = 0f;
    }
    public void PauseAndGameOver()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!gameIsPaused)
            {
                pausePanel.SetActive(true);
                gameIsPaused = true;
            }
            else
            {
                pausePanel.SetActive(false);
                gameIsPaused = false;
            }
        }

        if (gameIsOver) { gameOverPanel.SetActive(true); }
        else gameOverPanel.SetActive(false);
    }
    public void UnpauseButtonUI()
    {
        pausePanel.SetActive(false);
        gameIsPaused = false;
    }
    /* End of Methods for Pause and Gameover */

    /* Methods for Score And Clock */
    public void Scoring()
    {
        scoreText.GetComponent<Text>().text = string.Format("Score: {000000}", score);

        scoreTimer += Time.deltaTime;

        if (scoreTimer >= timeToScore)
        {
            score += scorePerMeter;
            scoreTimer = 0;
        }

        if (score < 0) score = 0;
        if (gameIsOver)
        {
            finalScore = score;
            finalScoreText.GetComponent<Text>().text = string.Format("Score: {000000}", score);
        }
    }
    public void ClockOfDeath()
    {   
        if (!isClockPaused)
        {
            clock -= Time.deltaTime;
        }

        clockText.GetComponent<Text>().text = string.Format("Time Left: {0:0#.00}", clock); /*"Time left: " + (int)clock;*/

        if (clock <= 0)
        {
            clock = 0;
            clockText.GetComponent<Text>().text = string.Format("Time Left: 00");
            gameIsOver = true;
        }
    }
    public void PauseClockOfDeath()
    {
        pauseTimer += Time.deltaTime;
        if (pauseTimer >= pausedTimeByClockStop)
        {
            isClockPaused = false;
            pauseTimer = 0;
        }
    }
    /* End of Methods for Score And Clock */
}