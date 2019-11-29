using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Health))]
public class ImpactAudio : MonoBehaviour
{
    [SerializeField] private SimpleAudioEvent audioEvent;
    private Health health;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Start()
    {
        health = GetComponent<Health>();
        health.OnTookHit += ImpactAudio_OnTookHit;
    }

    private void ImpactAudio_OnTookHit()
    {
        audioEvent.Play(audioSource);
    }

    private void OnDestroy()
    {
        //health.OnTookHit -= ImpactAudio_OnTookHit;
    }

}
