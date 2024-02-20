using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    private void Start()
    {
        SetVolume(1.0f);
    }
    public AudioMixer audioMixer;
    public AudioMixer SFX;
    // Start is called before the first frame update
   public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void Mute()
    {
        Debug.Log("mute");
        SFX.SetFloat("volume", -80);
    }
    public void Unmute()
    {
        SFX.SetFloat("volume", 0);
    }
}
