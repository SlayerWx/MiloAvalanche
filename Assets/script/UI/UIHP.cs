using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class UIHP : MonoBehaviour
{
    public TMP_Text text;
    private void OnEnable()
    {
        Life.OnChangeHP +=ChangeHP;
    }
    private void OnDisable()
    {

        Life.OnChangeHP -=ChangeHP;
    }
    void ChangeHP(int newHP,bool isAlive, float time)
    {
        text.text = newHP.ToString();
    }
}
