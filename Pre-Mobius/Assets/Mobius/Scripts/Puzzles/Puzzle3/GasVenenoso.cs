using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasVenenoso : MonoBehaviour
{

    float timer;
    [SerializeField] float maxTime;
    LightingManager lM;
    Inventario inventory;
    [SerializeField] Items item;

    private void Start()
    {
        lM = FindObjectOfType<LightingManager>();
        inventory = FindObjectOfType<Inventario>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("El player entro al incendio");
            if(item==null || !inventory.inventory.Contains(item))
            {
                Debug.Log("Aggghh me estoy que mando");
                timer += Time.deltaTime;
                if (timer >= maxTime)
                    {
                    lM.Loop();
                    }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        timer = 0;
    }



}
