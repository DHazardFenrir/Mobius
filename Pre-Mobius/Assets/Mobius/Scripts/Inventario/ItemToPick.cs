using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPick : MonoBehaviour, IInteractable
{
    public Items item;
    [SerializeField] Inventario inventario;
    [SerializeField] GameObject player;
    

    [SerializeField] float minD;
    //public float distance;
  
    [SerializeField] LayerMask itemMask;
    RaycastHit hit;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
     

        inventario = FindObjectOfType<Inventario>().GetComponent<Inventario>();
        check();
    }

    

    public void check()
    {
        if (inventario.inventory.Contains(item))
        {
            Destroy(this.gameObject);
        }
    }


    public void Interact()
    {
        Save();
    }

    public void Save()
    {
        var camera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
      

        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, minD, itemMask))
            {
               
                Debug.Log("Did Hit");
                inventario.inventory.Add(item);
                 Destroy(this.gameObject);
            }


            //if (distance <= minD)
            //{
            //    

            //}
            //else
            //{
            //    Debug.Log("ta bien lejos");
            //}
     }
    

  
}
