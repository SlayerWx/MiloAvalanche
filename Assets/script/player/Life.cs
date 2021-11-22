using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int initialHP;
    private int hp;
    void Start()
    {
        hp = initialHP;
    }
}
