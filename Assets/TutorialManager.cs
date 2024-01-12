using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] Canvas tutorialPage1;
    [SerializeField] Canvas tutorialPage2;
    [SerializeField] Canvas tutorialPage3;
    [SerializeField] Canvas mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        tutorialPage1.enabled = false;
        tutorialPage2.enabled = false;
        tutorialPage3.enabled = false;
    }

    // Update is called once per frame
    public void OpenTutorial()
    {
        mainMenu.enabled = false;
        tutorialPage1.enabled = true;
        tutorialPage2.enabled = false;
        tutorialPage3.enabled = false; 
    }

    public void QuitTutorial()
    {
        tutorialPage1.enabled = false;
        tutorialPage2.enabled = false;
        tutorialPage3.enabled = false;
        mainMenu.enabled = true;
    }

    public void TutorialPage2()
    {
        tutorialPage1.enabled = false;
        tutorialPage2.enabled = true;
        tutorialPage3.enabled = false;
    }

    public void TutorialPage3()
    {
        tutorialPage1.enabled = false;
        tutorialPage2.enabled = false;
        tutorialPage3.enabled = true;
    }
}
