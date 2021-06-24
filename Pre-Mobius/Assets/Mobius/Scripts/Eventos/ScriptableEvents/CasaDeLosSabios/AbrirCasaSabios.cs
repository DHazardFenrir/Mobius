using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCasaSabios : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Alma"))
        {
            Debug.Log("ChocoConLaPuerta");
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Active", true);
            Destroy(other.gameObject);
        }
    }

    

}
