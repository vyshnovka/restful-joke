using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sourceMain;
    [SerializeField]
    private AudioSource sourceSFX;

    [SerializeField]
    private List<Sound> soundsMain = new();
    [SerializeField] 
    private List<Sound> soundsSFX = new();

    public void PlaySFXSound(string name)
    {
        var sound = soundsSFX.Find(x => x.Name == name);

        Debug.Assert(sound != null, $"SFX sound with name {name} not found.");
        sourceSFX.PlayOneShot(sound?.Clip);
    }

    public void PlayMainSound(string name, bool loop = true, float delay = 0f)
    {
        var sound = soundsMain.Find(x => x.Name == name);

        Debug.Assert(sound != null, $"Theme sound with name {name} not found.");

        sourceMain.clip = sound?.Clip;
        sourceMain.loop = loop;

        sourceMain.PlayDelayed(delay);
    }
}
