using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    [SerializeField] Animator anim;
    bool opened;
    public void Interact()
    {
        if(opened)
        {
            anim.SetBool("Abierta", false);
        }
        else
        {
            anim.SetBool("Abierta", true);
        }
    }

}
