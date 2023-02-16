using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Sounds")]
    public AudioSource typing;
    public AudioSource mixing;

    [Header ("parameters")]
    public bool disableSfx;
    public float delay;

    private void Awake()
    {
        StartCoroutine(playAudio());
    }

    public void playTyping()
    {
        typing.Play();
    }
    public void playMixing()
    {
        mixing.Play();
    }
    IEnumerator playAudio()
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(playAudio());
    }
}
