using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float Points = 0;
    public float PointsForSpike = 0.25f;
    public GameObject DeadLayer;
    public UIPoints uiPoints;
    public int pointsToUnlock = 250;
    private void OnEnable()
    {
        Life.OnChangeHP += ChangeHP;
        BaseEnemy.OnSpikeEnd += AddPoints;
    }
    private void OnDisable()
    {
        Life.OnChangeHP -= ChangeHP;
        BaseEnemy.OnSpikeEnd -= AddPoints;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        Points = 0;
        uiPoints.text.text = ((int)Points).ToString();

    }
    void AddPoints()
    {
        Points += PointsForSpike;
        uiPoints.text.text = ((int)Points).ToString();
    }
    void ChangeHP(int newHP,bool isAlive,float time)
    {
        if(!isAlive)
        {
            StartCoroutine(EndGame(time));
        }
    }
    IEnumerator EndGame(float time)
    {
        CharacterInfo.myref.points = Points;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 0.0f;
        DeadLayer.SetActive(true);
    }
    public void SavePoints()
    {

        if(Points >= pointsToUnlock)
        {
            SlayerWxLogger.instance.Wirte(System.DateTime.Now.Month + " M/" + System.DateTime.Now.Day + " D/"
            + System.DateTime.Now.Year + " Y/" + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute +
            " T/- " + (int)Points + " Points");
            PlayGames.Instance.UnlockAchievement();
        }
    }
}
