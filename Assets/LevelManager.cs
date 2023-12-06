using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    SpawnWaves spawnWaves;
    [SerializeField] TMP_Text timerText;

    [SerializeField] float timer;
    private bool timerFinished;
    void Start()
    {
        timerFinished = false;
        spawnWaves = FindObjectOfType<SpawnWaves>();
    }


    void Update()
    {
        EndTimer();
        HideTimer();
        timer = timer - 1 * Time.deltaTime;
        timerText.text = timer.ToString("0.00");
      
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
}
