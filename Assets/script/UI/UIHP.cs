using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIHP : MonoBehaviour
{
    public TMP_Text text;
    private int initialHP;
    bool first = true;
    public Image imgCharacter;
    public Sprite[] spriteCharacterHeadRef;
    private void OnEnable()
    {
        Life.OnChangeHP +=ChangeHP;
        first = true;
    }
    private void OnDisable()
    {

        Life.OnChangeHP -=ChangeHP;
    }
    void ChangeHP(int newHP,bool isAlive, float time)
    {
        if(first)
        {
            initialHP = newHP;
            first = false;
        }
        text.text = newHP.ToString();
        imgCharacter.sprite = spriteCharacterHeadRef[(int)((newHP * (spriteCharacterHeadRef.Length - 1)) / initialHP)];
    }
}
