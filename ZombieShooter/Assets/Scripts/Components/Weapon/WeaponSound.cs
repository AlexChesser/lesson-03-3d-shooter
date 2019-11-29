using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponSound : WeaponComponent
{
    [SerializeField] private SimpleAudioEvent simpleAudio;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    protected override void WeaponFired()
    {
        simpleAudio.Play(audioSource);
    }
}
