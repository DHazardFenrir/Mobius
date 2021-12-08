using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] Transform punto;
   

    [SerializeField] AudioSource audio;


    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = punto.position;
            if (audio != null)
            {
                audio.Play();
            }
        }
    }


}
