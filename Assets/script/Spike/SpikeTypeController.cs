using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTypeController : MonoBehaviour
{
    public BaseEnemy myBaseEnemy;
    void Start()
    {
        myBaseEnemy.sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public void TheOnEnable()
    {
         if(!myBaseEnemy.sprite) myBaseEnemy.sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        myBaseEnemy.Update(transform.gameObject);
    }
}
