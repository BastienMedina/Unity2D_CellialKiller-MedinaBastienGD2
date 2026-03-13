using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound(AudioClip audio)
    {
        _audioSource.clip = audio;
        _audioSource.Play();
    }
    
}
