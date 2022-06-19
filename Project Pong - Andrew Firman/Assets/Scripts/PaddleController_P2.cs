using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController_P2 : MonoBehaviour
{
    [SerializeField] private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode downKey = KeyCode.DownArrow;
    [SerializeField] private float speed_modifier = 5;
    public Collider2D ball;
    private Rigidbody2D rig;
    private Vector3 tempScale;
    private int magnitude;

    private float speedTimer;
    private float panjangTimer;
    public float timeLimitSpeedup;
    public float timeLimitPanjangup;
    public PowerUpManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        magnitude = 1;
        tempScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
        speedTimer += Time.deltaTime;
        panjangTimer += Time.deltaTime;
        if (speedTimer > timeLimitSpeedup)
        {
            speedTimer = 0;
            magnitude = 1;
        }
        if (panjangTimer > timeLimitPanjangup)
        {
            transform.localScale = new Vector3(tempScale.x, tempScale.y);
            panjangTimer = 0;
        }
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
        rig.velocity = movement*magnitude;
        //Debug.Log("Paddle 2: " + movement);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            //#ball.GetComponent<BallController>().ActivePUSpeedUp(magnitude);
            manager.PaddleP2Hit();
            //Debug.Log("paddle2 hit!");
        }
    }
    public void ActivePUSpeedUp()
    {
        magnitude = 2;
    }
    public void ActivePUPanjangUp()
    {
        Debug.Log("Panjang up!");
        tempScale = transform.localScale;
        transform.localScale = new Vector3(tempScale.x, 4f);
    }
}
