using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Canvas levelEndCanvas;
    [SerializeField] Canvas gameOverCanvas;


    SpawnWaves spawnWaves;
    PlayerStats playerStats;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text gameOverTotalScore;
    [SerializeField] TMP_Text TotalScoreText;

    [SerializeField] float timer;
    static private int score;

    private bool timerFinished;
    private bool levelComplete;
    private bool gameOver;
    private void Awake()
    {
        levelEndCanvas.enabled = false;
        gameOverCanvas.enabled = false;
    }
    void Start()
    {
        gameOver = false;
        levelComplete = false;
        timerFinished = false;
        playerStats = FindObjectOfType<PlayerStats>();
        spawnWaves = FindObjectOfType<SpawnWaves>();
    }


    void Update()
    {
        GetGameOver();
        CheckGameOver();
        CheckLevelComplete();
        EndTimer();
        HideTimer();
        CreateTimer();
        UpdateTimerText();
        UpdateScoreText();
    }

    private void EndTimer()
    {
        if (timer <= 0f)
        {
            timerFinished = true;
        }

        if (timerFinished)
        {
            timer = 0f;
        }
    }

    public bool GetTimerFinished()
    {
        return timerFinished;
    }

    public void HideTimer()
    {
        if (timerFinished)
        {
            timerText.enabled = false;
        }
    }

    public void SetScore(int scoreAmount)
    {
        score += scoreAmount;
        if (score < 0)
        {
            score = 0;
        }
    }

    public int GetScore()
    {
        return score;
    }
    public void ResetScore()
    {
        score = 0;
    }
    private void CreateTimer()
    {
        timer -= (1 * Time.deltaTime);
    }
    private void UpdateTimerText()
    {
        timerText.text = timer.ToString("0.00");
    }
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        TotalScoreText.text = score.ToString();
        gameOverTotalScore.text = score.ToString();
    }

    public void SetLevelComplete(bool state)
    {
        levelComplete = state;
    }

    public bool GetLevelComplete()
    {
        return levelComplete;
    }

    public bool GetGameOver()
    {
        return gameOver = playerStats.GetPlayerDead();
    }
    private void CheckLevelComplete()
    {
        if (levelComplete)
        {
            levelEndCanvas.enabled = true;
            Time.timeScale = 0f;     
        }

        else
        {
            levelEndCanvas.enabled = false;
            Time.timeScale = 1f;   
        }
    }

    private void CheckGameOver()
    {
        if (gameOver)
        {
            gameOverCanvas.enabled = true;
            Time.timeScale = 0f;
        }

        else
        {
            gameOverCanvas.enabled = false;
            Time.timeScale = 1f;
        }
    }


    
}
