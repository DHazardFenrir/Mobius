using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    [SerializeField] private AudioSource theEndSound;
    [SerializeField] private GameObject finalLight;
    void Awake()
    {
        theEndSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       PlaySource();
        
    }

    void PlaySource()
    {
        if (!theEndSound.isPlaying && finalLight.activeSelf)
        {
            theEndSound.Play();
        }
    }

    
}
