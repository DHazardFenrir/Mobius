using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPick : MonoBehaviour
{
    public Items item;
    [SerializeField] Inventario inventario;

    private void Start()
    {
        inventario = FindObjectOfType<Inventario>().GetComponent<Inventario>();
        check();
    }

    public void check()
    {
        if (inventario.inventory.Contains(item))
        {
            Debug.Log("1");
            Destroy(this.gameObject);
            Debug.Log("2");
        }
    }

}
