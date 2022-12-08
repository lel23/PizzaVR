using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This class was made with help from this article: https://gamedevbeginner.com/singletons-in-unity-the-right-way/#:~:text=One%20of%20the%20main%20benefits,an%20audio%20manager%2C%20for%20example.

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public GameManager GameManager { get; private set; }
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
        AudioManager = GetComponentInChildren<AudioManager>();
        GameManager = GetComponentInChildren<GameManager>();
    }
}