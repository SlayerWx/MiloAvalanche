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
}
