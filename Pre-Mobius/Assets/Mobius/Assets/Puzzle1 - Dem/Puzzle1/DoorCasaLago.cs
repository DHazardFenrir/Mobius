using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCasaLago : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Items llave;
    Inventario inventario;
    bool opened;

    private void Start()
    {
        inventario=FindObjectOfType<Inventario>();    
    }  

    public void Interact()
    {
        if(inventario.inventory.Contains(llave))
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

    }
}
