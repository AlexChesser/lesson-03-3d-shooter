using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    [SerializeField] AudioClip[] clips = new AudioClip[0];
    [SerializeField] RangedFloat Volume = new RangedFloat(1, 1);
    [MinMaxRange(0, 2f)]
    [SerializeField] RangedFloat Pitch = new RangedFloat(1, 1);
    [MinMaxRange(0, 1000f)]
    [SerializeField] RangedFloat distance = new RangedFloat(1, 1000);
    [SerializeField] private AudioMixerGroup mixer;

    public void Play(AudioSource source) {
        source.outputAudioMixerGroup = mixer;
        int clipIndex = Random.Range(0, clips.Length);
        source.clip = clips[clipIndex];
        source.pitch = Random.Range(Pitch.minValue, Pitch.maxValue);
        source.volume = Random.Range(Volume.minValue, Volume.maxValue);
        source.minDistance = distance.minValue;
        source.maxDistance = distance.maxValue;
        source.Play();
    }
}
