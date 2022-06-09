using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public Collider2D ball;
    public bool isP1;
    public ScoreManager manager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision== ball)
        {
            Debug.Log("BOLA HIT!");
            if (isP1)
            {
                manager.AddScore("p1", 1);
            }
            else
            {
                manager.AddScore("p2", 1);
            }
        }
    }
}
