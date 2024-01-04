using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    AudioManager audioManager;
    LevelManager levelManager;

    private bool songIsPlaying;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        levelManager = FindObjectOfType<LevelManager>();
        songIsPlaying = false;
    }

    private void Update()
    {
        CheckCurrentLevel();
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
}
