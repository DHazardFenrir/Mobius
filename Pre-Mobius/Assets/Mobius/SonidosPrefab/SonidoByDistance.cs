using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SonidoByDistance : MonoBehaviour
{
    [SerializeField] private AudioSource nearestAudio;

    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        nearestAudio = FindObjectOfType<AudioSource>();
        if (maxDistance < 30)
        {
            nearestAudio = FindObjectOfType<AudioSource>();
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        GetAudio();
    }

    private void GetAudio()
    {
      
        
    }
}
