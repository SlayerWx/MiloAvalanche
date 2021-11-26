﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D myRigid;
    public float speed;
    public float axisMinMobileLimitSensitivity = 0.2f;
    public float MobileSensitivityMultiply = 1.5f;
    public SpriteRenderer bodyS;
    float leftLimit;
    float rightLimit;
    public GameObject b;
    public GameObject a;
    public GameObject c;
    void Start()
    {
        AnimationController.SetState(AnimationController.Animations.Idle);

        leftLimit = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        a = Instantiate(b, new Vector3(leftLimit, 5, 0), Quaternion.identity,null);

        rightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        c = Instantiate(b, new Vector3(rightLimit,5,0), Quaternion.identity, null);
    }

    void Update()
    {
        if (!AnimationController.GetTriggeredBool() )
        {
#if UNITY_ANDROID
            AccelMove();
#endif
            //#if UNITY_STANDALONE_WIN
#if UNITY_EDITOR
            Movement();
#endif
        }
        else
        {
            myRigid.velocity = new Vector2(0, myRigid.velocity.y);
        }
    }
#if UNITY_ANDROID
    private void AccelMove()
    {
        float horizontal = 0;
        if(Input.acceleration.x > axisMinMobileLimitSensitivity || Input.acceleration.x < -axisMinMobileLimitSensitivity)
        {
            horizontal = Input.acceleration.x * MobileSensitivityMultiply;
            if ((leftLimit < transform.position.x && horizontal <= 0) || (rightLimit > transform.position.x && horizontal >= 0))
            {
                if (!AnimationController.GetEqualAnim(AnimationController.Animations.Run))
                {
                    AnimationController.SetState(AnimationController.Animations.Run);
                }
                flipSprite(Input.acceleration.x);
            }
            else
            {
                horizontal = 0;
            }
        }
        else if(!AnimationController.GetEqualAnim(AnimationController.Animations.Idle))
        {
            AnimationController.SetState(AnimationController.Animations.Idle);
        }
        myRigid.velocity = new Vector2((horizontal * speed) * Time.deltaTime, myRigid.velocity.y);
    }
#endif
//#if UNITY_STANDALONE_WIN
#if UNITY_EDITOR
    private void Movement()
    {
        float horizontal = 0;
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
           horizontal = Input.GetAxis("Horizontal");
            if ((leftLimit < transform.position.x && horizontal <= 0) || (rightLimit > transform.position.x && horizontal >= 0))
            {
                if (!AnimationController.GetEqualAnim(AnimationController.Animations.Run))
                {
                    AnimationController.SetState(AnimationController.Animations.Run);
                }
                flipSprite(Input.GetAxis("Horizontal"));
            }
            else
            {
                horizontal = 0;
            }
        }
        else if (!AnimationController.GetEqualAnim(AnimationController.Animations.Idle))
        {
            AnimationController.SetState(AnimationController.Animations.Idle);
        }
        myRigid.velocity = new Vector2((horizontal * speed) * Time.deltaTime, myRigid.velocity.y);
    }
#endif
    void flipSprite(float aux)
    {
        if (Life.isAlive)
        {
            if (aux > 0)
                bodyS.flipX = false;
            else
                bodyS.flipX = true;
        }

    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("LeftLimit: " + a.transform.position.x);
        GUILayout.Label("rightLimit: " + c.transform.position.x);
    }
}
