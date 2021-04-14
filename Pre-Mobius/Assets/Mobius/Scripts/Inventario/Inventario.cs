using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public List<Items> inventory;

    private void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.T))
        {
            inventory.Add(FindObjectOfType<ItemToPick>().item);
            Destroy(FindObjectOfType<ItemToPick>().gameObject);
        }    

    }

    public bool check(Items item)
    {
        if(inventory.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
