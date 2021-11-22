using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float speed;
    void Update()
    {
        Falling();
    }
    void Falling()
    {
        transform.position += (Vector3.down * speed) * Time.deltaTime;
    }
}

