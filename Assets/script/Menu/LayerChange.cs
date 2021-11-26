using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    public GameObject ThisLayer;
    public void ShowLayer()
    {
        ThisLayer.SetActive(true);
    }
    public void HideLayer()
    {
        ThisLayer.SetActive(false);
    }
}
