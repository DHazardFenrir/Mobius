using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] Transform puntoA;
    [SerializeField] Transform puntoB;

    int lado = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(lado == 0)
            {
                other.transform.position = puntoB.transform.position;
                lado = 1;
            }
            else if(lado == 1)
            {
                other.transform.position = puntoA.transform.position;
                lado = 0;
            }
        }
    }


}
