using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float Points = 0;
    public float PointsForSpike = 0.25f;
    public float viewWaitToCoverPlayer;
    public GameObject DeadLayer;
    public UIPoints uiPoints;
    private void OnEnable()
    {
        Life.OnChangeHP += ChangeHP;
        Fall.OnSpikeEnd += AddPoints;
    }
    private void OnDisable()
    {
        Life.OnChangeHP -= ChangeHP;
        Fall.OnSpikeEnd -= AddPoints;
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
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 0.0f;
        //yield return new WaitForSecondsRealtime(viewWaitToCoverPlayer);
        DeadLayer.SetActive(true);
    }
}
