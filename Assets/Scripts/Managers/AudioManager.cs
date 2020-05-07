using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource audio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    public void PlayClip(AudioClip clip, float volume = 1,bool stop = false, float duration = 1)
    {
        audio.volume = volume;
        audio.PlayOneShot(clip);
        if (stop)
        {
            StartCoroutine(StopClip(duration));
        }
    }

    IEnumerator StopClip(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        audio.Stop();
    }
}
