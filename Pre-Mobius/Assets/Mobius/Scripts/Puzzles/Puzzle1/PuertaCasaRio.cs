using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCasaRio : MonoBehaviour, IInteractable
{
    [SerializeField] Items item;
    [SerializeField] Inventario inventario;
    
    private void Start()
    {
        inventario = FindObjectOfType<Inventario>();    
    }

    public void Interact()
    {
        if(inventario.inventory.Contains(item))
        {
        OpenDoor();
        }
        else
        {
            Debug.Log("No tienes el item");
        }
    }

    void OpenDoor()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Active", true);
    }

}
