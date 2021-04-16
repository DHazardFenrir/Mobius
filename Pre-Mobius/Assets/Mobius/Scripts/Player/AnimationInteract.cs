using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteract : MonoBehaviour, IInteractable
{
    Inventario inventario;
    Items item;
    Animator anim;

    private void Start()
    {
        inventario = FindObjectOfType<Inventario>();
        anim = GetComponent<Animator>();
    }


    public void Interact()
    {
        if(inventario.inventory.Contains(item))
        {
            anim.SetBool("Active", true);
        }
    }

}
