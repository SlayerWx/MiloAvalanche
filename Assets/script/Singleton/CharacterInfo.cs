using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum CharacterType
{
    Dog, Cat
}
public class CharacterInfo : MonoBehaviour
{
    public static Action OnInitScene;
    public static CharacterInfo myref = null;
    public float points;
    public bool haveCat;
    public CharacterType actualCharacterType;
    void Start()
    {
        if (this != myref && myref)
            Destroy(this);
        else if (myref)
            OnInitScene?.Invoke();
        else
        {
            myref = this;
            OnInitScene?.Invoke();
        }
    }

    
}
