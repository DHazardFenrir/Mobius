using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPick : MonoBehaviour
{
    public Items item;
    [SerializeField] Inventario inventario;

    [SerializeField] float minD;
    //public float distance;
    Transform player;
    [SerializeField] LayerMask itemMask;
    RaycastHit hit;

    

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        inventario = FindObjectOfType<Inventario>().GetComponent<Inventario>();
        check();
    }

    private void Update()
    {
        Save();
        distance = Vector3.Distance(transform.position, player.position);
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

    public void Save()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, minD, itemMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
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

}
