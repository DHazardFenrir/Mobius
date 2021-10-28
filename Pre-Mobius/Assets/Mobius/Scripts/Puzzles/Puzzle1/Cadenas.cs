using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenas : MonoBehaviour, IInteractable
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject altar;

     void Start()
    {
        
    }
    public void Interact()
    {
        DryLake();
    }

    void DryLake()
    {
        Debug.Log("enter");
        anim.SetBool("Active", false);
        altar.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("Dry Lake");
    }
}
