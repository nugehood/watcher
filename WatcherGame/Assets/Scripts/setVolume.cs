using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void setAmbient(float sliderValue)
    {
        mixer.SetFloat("ambientVol", Mathf.Log10(sliderValue) * 20);
    }

    public void setFx(float sliderValue)
    {
        mixer.SetFloat("fxVol", Mathf.Log10(sliderValue) * 20);
    }
}
