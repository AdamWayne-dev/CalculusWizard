using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Canvas levelEndCanvas;
   
    

    SpawnWaves spawnWaves;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text TotalScoreText;

    [SerializeField] float timer;
    private int score;

    private bool timerFinished;
    private bool levelComplete;
    private void Awake()
    {
        levelEndCanvas.enabled = false;
    }
    void Start()
    {
        
        levelComplete = false;
        timerFinished = false;
        spawnWaves = FindObjectOfType<SpawnWaves>();
    }


    void Update()
    {
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
    }

    public void SetLevelComplete(bool state)
    {
        levelComplete = state;
    }

    public bool GetLevelComplete()
    {
        return levelComplete;
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


    
}
