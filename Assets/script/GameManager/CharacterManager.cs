using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterManager : MonoBehaviour
{
    public Character dog;
    public Character cat;
    public Animator anim;
    public UIHP uihp;
    private void OnEnable()
    {
        CharacterInfo.OnInitScene += SetCharacter;
    }
    private void OnDisable()
    {

        CharacterInfo.OnInitScene -= SetCharacter;
    }
    void SetCharacter()
    {
        if(CharacterInfo.myref.actualCharacterType == CharacterType.Dog)
        {
            SettingCharacter(dog);
        }
        else if(CharacterInfo.myref.actualCharacterType == CharacterType.Cat)
        {
            if(CharacterInfo.myref.haveCat)
            {
                SettingCharacter(cat);
            }
            else
            {
                SettingCharacter(dog);
            }
        }
    }
    void SettingCharacter(Character ch)
    {
        anim.runtimeAnimatorController = ch.animatorController;
        for (int i = 0; i < ch.LifeHPSprite.Length;i++)
        {
            uihp.spriteCharacterHeadRef[i] = ch.LifeHPSprite[i];
        }
    }

}
