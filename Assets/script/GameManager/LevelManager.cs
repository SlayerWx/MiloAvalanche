using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float viewWaitToCoverPlayer;
    public GameObject DeadLayer;
    private void OnEnable()
    {
        Life.OnChangeHP -= ChangeHP;
    }
    private void OnDisable()
    {
        Life.OnChangeHP -= ChangeHP;
    }
    void Start()
    {
        Time.timeScale = 1.0f;

    }
    void ChangeHP(int newHP)
    {
        if(newHP <= 0)
        {
            StartCoroutine(EndGame());
        }
    }
    IEnumerator EndGame()
    {
        Time.timeScale = 0.0f;
        yield return new WaitForSeconds(viewWaitToCoverPlayer);
        DeadLayer.SetActive(true);
    }
}
