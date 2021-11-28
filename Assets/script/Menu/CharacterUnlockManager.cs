using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterUnlockManager : MonoBehaviour
{
    public float catChallenge;
    public Button canHasCat;
    public Image catSprite;
    public PluginManager PM;

    void OnEnable()
    {
        CheckCatChallenge();
        if(PM)
        PM.WirteLog();
    }
    public void CheckCatChallenge()
    {
        if (CharacterInfo.myref.points >= catChallenge)
        {
            PlayGames.Instance.UnlockAchievement();
        }
        if(PlayGames.Instance)
        canHasCat.interactable = PlayGames.Instance.GetSuccessArchivment();
    }
    public void CheckCatChallengeInteract()
    {
        canHasCat.interactable = PlayGames.Instance.GetSuccessArchivment();
    }
}
