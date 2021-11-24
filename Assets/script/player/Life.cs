using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Life : MonoBehaviour
{
    public int initialHP;
    private int hp;
    public static Action<int,bool,float> OnChangeHP;
    public float invulnerabilityTime;
    public float deadAnimTime;
    public float hurtANimTime;
    bool canHurt;
    public static bool isAlive;
    public ParticleSystem blood;
    void Start()
    {
        SetHP(initialHP);
        canHurt = true;
        isAlive = true;
        OnChangeHP?.Invoke(hp, isAlive,0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && canHurt)
        {
            SetHP(hp - 1);
            blood.Play();
            if (hp > 0)
            {
                AnimationController.SetState(AnimationController.Animations.Hurt);
                AnimationController.SetTriggeredBool(true);
                StartCoroutine(animTime(hurtANimTime));
            }
        }
    }
    public void SetHP(int newHP)
    {
        hp = newHP;
        if (hp <= 0)
        {
            AnimationController.SetState(AnimationController.Animations.Dead);
            AnimationController.SetTriggeredBool(true);
            isAlive = false;
            StartCoroutine(animTime(deadAnimTime));
        }
    }
    IEnumerator animTime(float time)
    {
        OnChangeHP?.Invoke(hp, isAlive,time);
        canHurt = false;
        yield return new WaitForSecondsRealtime(time);
        AnimationController.SetTriggeredBool(false);
        yield return new WaitForSecondsRealtime(invulnerabilityTime);
        canHurt = true;
    }
}
