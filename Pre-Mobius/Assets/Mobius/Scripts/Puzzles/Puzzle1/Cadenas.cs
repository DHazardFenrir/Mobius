using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenas : MonoBehaviour, IInteractable
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject altar;
    [SerializeField] private GameObject rioAudio;
    [SerializeField] private AudioSource nuevoAudio;
    [SerializeField] private AudioSource chainPull;

     void Start()
     {
         nuevoAudio = GetComponent<AudioSource>();
     }
    public void Interact()
    {
        DryLake();
    }

    void DryLake()
    {
        chainPull.Play();
        Debug.Log("enter");
        anim.SetBool("Active", false);
        altar.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("Dry Lake");
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        rioAudio.SetActive(false);
        nuevoAudio.Play();
    }
}
