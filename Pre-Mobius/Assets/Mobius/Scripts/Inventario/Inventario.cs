using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public List<Items> inventory;


    private void Start()
    {
    }

    private void Update()
    {

        //Save();


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

    public void Save()
    {
        if (Input.GetMouseButtonDown(1))
        {
 
            inventory.Add(FindObjectOfType<ItemToPick>().item);
            Destroy(FindObjectOfType<ItemToPick>().gameObject);

        }

    }
}
