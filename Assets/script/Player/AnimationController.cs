using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public enum Animations
    { 
        Idle,Run,Hurt,Dead
    };
    public static Animator myAnim;
    void Awake()
    {
        myAnim = GetComponent<Animator>();
        
    }
    public static void StartAnim()
    {
        myAnim.SetTrigger("StartAnim");
    }
    public static void SetState(Animations newState)
    {
        myAnim.SetInteger("PlayerState",(int)newState);
    }
    public static bool GetEqualAnim(Animations newState)
    {
        return (myAnim.GetInteger("PlayerState") == (int)newState);
    }
    public static void SetTriggeredBool(bool isTriggered)
    {
        myAnim.SetBool("triggeredAnim",isTriggered);
    }
    public static bool GetTriggeredBool()
    {
        return myAnim.GetBool("triggeredAnim");
    }
}
