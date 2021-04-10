using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHouse : MonoBehaviour, IInteractable
{

    void KnockKnock()
    {
        Debug.Log("Knock Knock Travis" + gameObject.name);
    }
    public void Interact()
    {
        KnockKnock();
    }
}
