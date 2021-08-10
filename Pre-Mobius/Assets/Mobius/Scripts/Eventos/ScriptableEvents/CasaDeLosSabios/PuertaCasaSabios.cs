using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCasaSabios : MonoBehaviour, IInteractable
{

    Animator anim;
    bool soulTrigger;
    bool opened;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        if(soulTrigger)
        {
            if (opened)
            {
                anim.SetBool("Abierta", false);
            }
            else
            {
                anim.SetBool("Abierta", true);
            }
        }
        else
        {
            Debug.Log("Aun no se puede abrir");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Alma"))
        {
            anim.SetBool("Abierta", true);
            soulTrigger = true;
        }
    }


}
