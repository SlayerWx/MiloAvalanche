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
    public CharacterType actualCharacterType;
    void Awake()
    {
        if (!myref)
            myref = this;
        else
            Destroy(this);
    }

    
}
