using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource audioS;

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
        audioS = GetComponent<AudioSource>();
    }


    public void PlayClip(AudioClip clip, float volume = 1,bool stop = false, float duration = 1)
    {
        audioS.volume = volume;
        audioS.PlayOneShot(clip);
        if (stop)
        {
            StartCoroutine(StopClip(duration));
        }
    }

    IEnumerator StopClip(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        audioS.Stop();
    }
}
