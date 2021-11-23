using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D myRigid;
    public float speed;
    public float axisMinMobileLimitSensitivity = 0.2f;
    public float MobileSensitivityMultiply = 1.5f;
    public SpriteRenderer bodyS;
    void Start()
    {
        AnimationController.SetState(AnimationController.Animations.Idle);
    }

    void Update()
    {
        if (!AnimationController.GetTriggeredBool())
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
            if (!AnimationController.GetEqualAnim(AnimationController.Animations.Run))
            {
                AnimationController.SetState(AnimationController.Animations.Run);
            }
            flipSprite(Input.acceleration.x);
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
            if (!AnimationController.GetEqualAnim(AnimationController.Animations.Run))
            {
                AnimationController.SetState(AnimationController.Animations.Run);
            }
            flipSprite(Input.GetAxis("Horizontal"));
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
        if (aux > 0)
            bodyS.flipX = false;
        else
            bodyS.flipX = true;

    }
}
