using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        var nearestGameObject = GetNearestGameObject();
        if (nearestGameObject == null) return;
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            var interactable = nearestGameObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }

    private GameObject GetNearestGameObject()
    {
        GameObject result = null;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hit, 10))
        {
            result = hit.transform.gameObject;
        }
        return result;
    }
}
