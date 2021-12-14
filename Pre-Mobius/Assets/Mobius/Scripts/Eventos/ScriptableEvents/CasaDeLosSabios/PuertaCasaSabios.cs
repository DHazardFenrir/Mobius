using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCasaSabios : MonoBehaviour, IInteractable
{

    Animator anim;
    [SerializeField] bool soulTrigger;
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
                opened = !opened;
                anim.SetBool("Abierta", false);
            }
            else
            {
                opened = !opened;
                anim.SetBool("Abierta", true);
            }
        }
        else
        {
            Debug.Log("Aun no se puede abrir");
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Alma"))
        {
            anim.SetBool("Abierta", true);
            soulTrigger = true;
            opened = true;
        }
    }

}
