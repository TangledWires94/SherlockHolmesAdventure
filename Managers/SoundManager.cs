using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SoundManager : Manager<SoundManager>
{
    public List<AudioClip> SoundEffectClips = new List<AudioClip>();
    public enum SoundEffectNames { FoundClue, Unlock, OpenDoor, Lawyers };
    Dictionary<SoundEffectNames, AudioClip> SoundEffects = new Dictionary<SoundEffectNames, AudioClip>();
    public AudioClip backgroundMusic;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        List<SoundEffectNames> enumValues = Enum.GetValues(typeof(SoundEffectNames)).Cast<SoundEffectNames>().ToList();
        for(int i = 0; i < enumValues.Count; i++)
        {
            SoundEffects.Add(enumValues[i], SoundEffectClips[i]);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    public void PlaySoundEffect(SoundEffectNames soundEffectName)
    {
        audioSource.PlayOneShot(SoundEffects[soundEffectName]);
    }
}
