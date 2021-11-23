using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fall : MonoBehaviour
{
    public float speed;
    public float endYPos;
    public static Action OnSpikeEnd;
    public SpriteRenderer sprite;
    private void OnEnable()
    {
        
        sprite.flipX = (UnityEngine.Random.Range(0, 2) == 1);
    }
    void Update()
    {
        Falling();
    }
    void Falling()
    {
        transform.position += (Vector3.down * speed) * Time.deltaTime;
        if (transform.position.y < endYPos)
        {
            OnSpikeEnd?.Invoke();
            gameObject.SetActive(false);
        }
    }
}

