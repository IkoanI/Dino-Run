using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScenes : MonoBehaviour
{
    public void ToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ToEnd()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void ToLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void ToEmailThankYou()
    {
        SceneManager.LoadScene("EmailThankYouScene");
    }

    public void ToThankYou()
    {
        SceneManager.LoadScene("ThankYouScene");
    }

    public void ToStart()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
