using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterUnlockManager : MonoBehaviour
{
    public float catChallenge;
    public Button canHasCat;
    public Image catSprite;
    private void Start()
    {
    }
    void OnEnable()
    {
        if(CharacterInfo.myref.points >= catChallenge)
        {
            canHasCat.interactable = true;
        }
    }
}
