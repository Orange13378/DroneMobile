using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public void AudioVolume(Slider sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue.value);
    }
}