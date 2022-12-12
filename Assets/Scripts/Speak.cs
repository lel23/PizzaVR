using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speak : MonoBehaviour
{
    private AudioSource audioSource;

    public Sound[] voicelines;

    private Sound currentLine;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(sayVoiceline());
    }

    IEnumerator sayVoiceline()
    {
        currentLine = voicelines[Random.Range(0, voicelines.Length - 1)];
        audioSource.pitch = Random.Range(-3.0f, 3.0f);
        yield return new WaitForSeconds(currentLine.clip.length + Random.Range(0.0f, 60.0f));
    }
}
