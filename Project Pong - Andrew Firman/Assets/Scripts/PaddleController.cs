using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;
    [SerializeField] private float speed_modifier = 3;
    private Rigidbody2D rig;
    public Collider2D ball;
    public PowerUpManager manager;
    private int magnitude;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        magnitude = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());

    }
    private Vector2 GetInput()
    {
        // get input
        if (Input.GetKey(upKey))
        {
            return (Vector2.up * speed_modifier);
        }
        else if (Input.GetKey(downKey))
        {
            return (Vector2.down * speed_modifier);
        }
        return Vector2.zero;

    }
    private void MoveObject(Vector2 movement)
    {
        rig.velocity= (movement*magnitude);
        // Debug.Log("Paddle 1: "+movement);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            //#ball.GetComponent<BallController>().ActivePUSpeedUp(magnitude);
            manager.PaddleP1Hit();
            //Debug.Log("paddle2 hit!");
        }
    }
    public void ActivePUSpeedUp()
    {
        Debug.Log("Speeding up!");
        magnitude = 2;
    }
}
