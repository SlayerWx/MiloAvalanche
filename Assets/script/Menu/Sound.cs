using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Sound : MonoBehaviour
{
    public AudioMixer AM;
    public Slider slider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        PlayerPrefs.SetFloat("volume", slider.value);
        slider.value = PlayerPrefs.GetFloat("volume");
        AM.SetFloat("volume", slider.value);
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }
    public void OnChangeSlider()
    {
        AM.SetFloat("volume",slider.value);
    }
}
