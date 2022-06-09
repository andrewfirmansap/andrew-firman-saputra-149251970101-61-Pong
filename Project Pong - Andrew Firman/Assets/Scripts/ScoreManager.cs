using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score_p1,score_p2;
    public int maxScore=10;
    public BallController ballcontroller;
    public void AddScore(string p_side, int increment)
    {
        if (p_side == "p1")
        {
            score_p1 += increment;
        }
        if (p_side == "p2")
        {
            score_p2 += increment;
        }
        ballcontroller.ResetBall();
        if (score_p1 >= maxScore || score_p2 >= maxScore)
        {
            GameOver();
        }


    }
    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
