using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fall : MonoBehaviour
{
    public float speed;
    public float endYPos;
    public static Action OnSpikeEnd;
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

