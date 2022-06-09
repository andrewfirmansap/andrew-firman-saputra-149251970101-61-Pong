using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text P1_score;
    public Text P2_score;
    public ScoreManager manager;
    // Update is called once per frame
    void Update()
    {
        P1_score.text = manager.score_p1.ToString();
        P2_score.text = manager.score_p2.ToString();

    }
}
