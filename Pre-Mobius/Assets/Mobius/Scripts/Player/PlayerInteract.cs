using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] GameObject texto;
    [SerializeField] LayerMask interactableMask;
    [SerializeField] LayerMask defaultMask;

 

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        var nearestGameObject = GetNearestGameObject();
        
        if (nearestGameObject == null) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            var interactable = nearestGameObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }

    private GameObject GetNearestGameObject()
    {
        texto = GameObject.FindGameObjectWithTag("InteractiveText");
        GameObject result = null;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hit, 5f, interactableMask))
        {
            result = hit.transform.gameObject;
           
            if (result.CompareTag("Interactable") && interactableMask.value.Equals(9))
            {
                texto.SetActive(true);
            }

            if (result && interactableMask.value.Equals(0))
            {
                texto.SetActive(false);
                Debug.Log("mascara default");
            }

           

        }
        return result;
    }

    

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
          
            Debug.Log("Se entro en un Interactable");
            
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                other.GetComponent<IInteractable>().Interact();
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            
        }
    }

}
