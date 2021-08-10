using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reemplazar : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject ofrendaReal;
    [SerializeField] GameObject ofrendaFalsa;

    [SerializeField] Items itemRequerido;

    Inventario inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventario>();        
    }

    public void Interact()
    {
        if(inventory.inventory.Contains(itemRequerido))
        {
        Destroy(ofrendaFalsa);
        ofrendaReal.SetActive(true);

        inventory.inventory.Add(ofrendaFalsa.GetComponent<ItemToPick>().item);
        inventory.inventory.Remove(itemRequerido);
        }
    }



}
