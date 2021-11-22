using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D myRigid;
    public float speed;
    public float axisMinMobileLimitSensitivity = 0.2f;
    public float MobileSensitivityMultiply = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        AccelMove();
#endif
        //#if UNITY_STANDALONE_WIN
#if UNITY_EDITOR
        Movement();
#endif
    }
    private void AccelMove()
    {
        float horizontal = 0;
        if(Input.acceleration.x > axisMinMobileLimitSensitivity || Input.acceleration.x < -axisMinMobileLimitSensitivity)
        {
            horizontal = Input.acceleration.x * MobileSensitivityMultiply;
        }
        myRigid.velocity = new Vector2((horizontal * speed) * Time.deltaTime, myRigid.velocity.y);
    }
    private void Movement()
    {
        float horizontal = 0;
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        myRigid.velocity = new Vector2((horizontal * speed) * Time.deltaTime, myRigid.velocity.y);
    }
}
