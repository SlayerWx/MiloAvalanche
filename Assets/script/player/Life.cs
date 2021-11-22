using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Life : MonoBehaviour
{
    public int initialHP;
    private int hp;
    public static Action<int> OnChangeHP;

    void Start()
    {
        SetHP(initialHP);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SetHP(hp - 1);
        }
    }
    public void SetHP(int newHP)
    {
        hp = newHP;
        OnChangeHP?.Invoke(hp);
    }
}
