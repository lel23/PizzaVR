using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] voicelines;

    private AudioClip currentLine;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1.0f;
    }

    void Update()
    {
        StartCoroutine(sayVoiceline());
    }

    IEnumerator sayVoiceline()
    {
        currentLine = voicelines[Random.Range(0, voicelines.Length - 1)];
        audioSource.pitch = Random.Range(-3.0f, 3.0f);
        audioSource.clip = currentLine;
        Debug.Log("said voiceline");
        audioSource.Play();
        yield return new WaitForSeconds(currentLine.length + Random.Range(0.0f, 60.0f));
    }
}
