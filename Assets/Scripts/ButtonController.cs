using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // MENU VARIABLES
    public GameObject restartMenu;
    public ScoreController scoreController;
    public UnityAdsController adController;

    public FadeInScene fadeScene;

    private void Start()
    {
        // Time.timeScale = 1;
        scoreController = FindObjectOfType<ScoreController>();
        adController = FindObjectOfType<UnityAdsController>();
        fadeScene = FindObjectOfType<FadeInScene>();
        restartMenu.SetActive(false);
    }

    public void RestartScreen()
    {
        // Time.timeScale = 0;
        Debug.Log("Restart Screen Active");
        Debug.Log("Current score: " + scoreController.score);
        restartMenu.SetActive(!restartMenu.activeSelf);
    }


    public void PlayGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        //FindObjectOfType<ScoreController>().ResetScore();
        ScoreController.instance.ResetScore();
        Debug.Log("Current score: " + scoreController.score);
        restartMenu.SetActive(false);
        SceneManager.LoadScene("Game");
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Debug.Log("Current score: " + scoreController.score);
        restartMenu.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        Debug.Log("Current score: " + scoreController.score);
        
        
        
        // play an ad
        //AdmobAds.instance.showVideoAd();
        adController.ShowRewardedVideo();
        Time.timeScale = 1;
        
        
        restartMenu.SetActive(false);
        // SceneManager.LoadScene("Main Menu");
    }
}
