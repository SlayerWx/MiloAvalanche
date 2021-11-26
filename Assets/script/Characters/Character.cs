using UnityEngine;
[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class Character : ScriptableObject
{
    public RuntimeAnimatorController animatorController;
    public Sprite[] LifeHPSprite;
}
