using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    void Point()
    {
        Debug.Log(gameObject.name + "tree leafy leafy");
    }
    public void Interact()
    {
        Point();
    }
}
