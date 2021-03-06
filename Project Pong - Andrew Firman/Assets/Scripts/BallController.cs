using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 speed = new Vector2(4, 4);
    private Rigidbody2D rig;
    [SerializeField] private Vector3 resetPosition = new Vector3(0, 1.4f, 2f);
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void ResetBall()
    {
        transform.position = resetPosition;
        rig.velocity = -rig.velocity;
    }
    public void ActivePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }
}
