using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSelect : MonoBehaviour
{
    public CharacterType ch;
    public Image container;
    private void Start()
    {
        if(ch == CharacterInfo.myref.actualCharacterType)
        {
            container.color = Color.yellow;
        }
    }
    public void SelectCharacter()
    {   
        CharacterInfo.myref.actualCharacterType = ch;
        container.color = Color.yellow;
    }
    public void UnSelected()
    {
        container.color = Color.white;
    }
}
