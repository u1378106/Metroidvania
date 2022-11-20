using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider Music, SFX;
    public void Start()
    {
        //if (PlayerPrefs.HasKey("MusicVolume"))
        //    Music.value = PlayerPrefs.GetFloat("MusicVolume");
        //if (PlayerPrefs.HasKey("SFXVolume"))
        //    SFX.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void AdjustMusicVolume(float sliderValue)
    {
        AudioManager.instance.sounds[0].source.volume = this.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("MusicVolume", this.GetComponent<Slider>().value);
    }
    public void AdjustSFXVolume(float sliderValue)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }
    //public void AdjustMasterVolume(float volume)
    //{
    //    audioMixer.SetFloat("MasterVolume", volume);
    //}
}
