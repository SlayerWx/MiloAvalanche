using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShowSlider : Button
{
    public GameObject[] toShowAndHide;
    float time;
    protected override void Start()
    {
        base.Start();
        SliderHideData aux = GetComponent<SliderHideData>();
        toShowAndHide = aux.ObjToShow;
        time = aux.timer;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        StopAllCoroutines();
        Show();
    }

    public void OnchangeValue()
    {
        StopAllCoroutines();
        StartCoroutine(Hide());
    }
    public void Show()
    {
        foreach(GameObject a in toShowAndHide)
        {
            a.SetActive(true);
        }
    }
    IEnumerator Hide()
    {
        yield return new WaitForSecondsRealtime(time);
        foreach (GameObject a in toShowAndHide)
        {
            a.SetActive(false);
        }
    }
    
}
