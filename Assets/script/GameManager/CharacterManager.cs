using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterManager : MonoBehaviour
{
    public Character dog;
    public Character cat;
    public Animator anim;
    public UIHP uihp;

    void Start()
    {
        SetCharacter();
    }
    void SetCharacter()
    {
        if (CharacterInfo.myref.actualCharacterType == CharacterType.Dog)
        {
            SettingCharacter(dog);
        }
        else if (CharacterInfo.myref.actualCharacterType == CharacterType.Cat)
        {

            SettingCharacter(cat);
        }
    }
    void SettingCharacter(Character ch)
    {
        anim.runtimeAnimatorController = ch.animatorController;
        for (int i = 0; i < ch.LifeHPSprite.Length; i++)
        {
            uihp.spriteCharacterHeadRef[i] = ch.LifeHPSprite[i];

        }
        uihp.imgCharacter.sprite = ch.LifeHPSprite[ch.LifeHPSprite.Length - 1];
    }

    
}
