using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class BaseEnemy
{
    public float speed;
    public float endYPos;
    public static Action OnSpikeEnd;
    public SpriteRenderer sprite;
    public BaseEnemy me;
    public Color myColor;

    public BaseEnemy(Color newColor,float speed,float endYPos)
    {
        this.speed = speed;
        this.endYPos = endYPos;
        myColor = newColor;
        me = this;
    }
    public virtual void OnEnable(GameObject GM)
    {
       
        sprite.flipX = (UnityEngine.Random.Range(0, 2) == 1);
        sprite.color = myColor;
        GM.transform.rotation = Quaternion.Euler(0,0,0);
    }
    public virtual void Update(GameObject GM)
    {
        Falling(GM);
    }
    void Falling(GameObject GM)
    {
        FallingStyle(GM);
        if (GM.transform.position.y < endYPos)
        {
            OnSpikeEnd?.Invoke();
            GM.SetActive(false);
        }
    }
    protected abstract void FallingStyle(GameObject GM);
}
