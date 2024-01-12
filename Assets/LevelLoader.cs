using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    AudioManager audioManager;
    LevelManager levelManager;

    [SerializeField] Canvas pauseScreen;
    

    private bool songIsPlaying;
    private bool isPaused;
    private void Start()
    {
        isPaused = false;
        pauseScreen.enabled = false;
        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
        songIsPlaying = false;
    }

    private void Update()
    {
        CheckCurrentLevel();
        PauseGame();
    }
    public void LoadNextLevel()
    {
        audioManager.SetIsPlayingMusic(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        audioManager.SetIsPlayingMusic(false);
        levelManager.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        audioManager.SetIsPlayingMusic(false);
        levelManager.ResetScore();
        SceneManager.LoadScene(0);
    }

    private void CheckCurrentLevel()
    {

        switch (SceneManager.GetActiveScene().buildIndex)
        {

            case 0:
                
                break;

            case 1:
                audioManager.PlayBackgroundMusic(0);
                break;

            case 2:
                audioManager.PlayBackgroundMusic(0);
                break;

            case 3:
                break;
        }


    }

    private void PauseGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (!isPaused && Input.GetKeyDown(KeyCode.P))
            {
                isPaused = !isPaused;
                pauseScreen.enabled = true;
                Time.timeScale = 0f;
            }

            else if (isPaused && Input.GetKeyDown(KeyCode.P))
            {
                isPaused = !isPaused;
                pauseScreen.enabled = false;
                Time.timeScale = 1f;
            }
        }
    }

  public void ResumeGame()
    {
        isPaused = false;
        pauseScreen.enabled = false;
        Time.timeScale = 1f;
    }

    public bool GetPausedStatus()
    {
        return isPaused;
    }
}
