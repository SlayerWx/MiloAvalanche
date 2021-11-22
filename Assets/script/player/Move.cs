using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D myRigid;
    public float speed;
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

    }
    private void Movement()
    {
        float horizontal = 0;
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        myRigid.velocity = new Vector2(horizontal * speed, myRigid.velocity.y);
    }
}
