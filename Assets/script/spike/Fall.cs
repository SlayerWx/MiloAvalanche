using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float speed;
    public float endYPos;
    void Update()
    {
        Falling();
    }
    void Falling()
    {
        transform.position += (Vector3.down * speed) * Time.deltaTime;
        if (transform.position.y < endYPos) gameObject.SetActive(false);
    }
}

