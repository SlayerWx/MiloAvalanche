using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    public GameObject thisLayer;
    public GameObject nextLayer;
    public void ShowLayer()
    {
        thisLayer.SetActive(true);
    }
    public void HideLayer()
    {
        thisLayer.SetActive(false);
    }
    public void Pause()
    {
        thisLayer.SetActive(false);
        Time.timeScale = 0.0f;
        nextLayer.SetActive(true);
    }
    public void UnPause()
    {
        thisLayer.SetActive(true);
        Time.timeScale = 1.0f;
        nextLayer.SetActive(false);
    }
}
