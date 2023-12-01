using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject scoreManager;
    Score scoreScr;
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        scoreScr.score = 0;
    }

    public void Exit()
    {
        Application.Quit();
        scoreScr.score = 0;
    }
    private void Update()
    {
        scoreManager = GameObject.FindWithTag("ScoreManager");
        scoreScr = scoreManager.GetComponent<Score>();
    }
}
