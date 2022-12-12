using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was made with help from this video: https://www.youtube.com/watch?v=dJB07ZSiW7k

public class PizzaRecipient : MonoBehaviour
{
    public Material startMaterial;
    public Material endMaterial;

    private GameObject head;
    private GameObject body;

    private AudioSource audio;

    void Start()
    {
        head = transform.GetChild(0).gameObject;
        body = transform.GetChild(1).gameObject;

        head.GetComponent<Renderer>().enabled = true;
        body.GetComponent<Renderer>().enabled = true;
        head.GetComponent<Renderer>().sharedMaterial = startMaterial;
        body.GetComponent<Renderer>().sharedMaterial = startMaterial;

        audio = GetComponent<AudioSource>();
    }

    public void changeColor()
    {
        Debug.Log("changed color");
        head.GetComponent<Renderer>().sharedMaterial = endMaterial;
        body.GetComponent<Renderer>().sharedMaterial = endMaterial;
    }

    public void makeYayNoise()
    {
        audio.Play();
    }
    

}
