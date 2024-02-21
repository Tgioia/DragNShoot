using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{public AudioMixer audioMixer;
    public AudioMixer SFX;
    private void Start()
    {
        SetVolume(1.0f);
    }
    
    // Start is called before the first frame update
   public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SFXToggle(bool toggle)
    {
        if (toggle) {
            //attiva
            SFX.SetFloat("volume", 0f);
        }
        else {
            //disattiva
            SFX.SetFloat("volume", -80f);
        }
    }
}
