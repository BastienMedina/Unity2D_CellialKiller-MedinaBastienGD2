using UnityEngine;

public class FootStepsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void UpdateFootsteps(bool state)
    {
        if (state)
        {
            _audioSource.Play();
            _audioSource.loop = true;
        }
        else
        {
            _audioSource.loop = false;
            _audioSource.Stop();
        }
    }
}
