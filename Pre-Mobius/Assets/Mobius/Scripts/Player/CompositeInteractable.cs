using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> interactables;

    public void Interact()
    {
        Debug.Log("Interact");
        foreach(var go in interactables)
        {
            var interactable = go.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
   
}
