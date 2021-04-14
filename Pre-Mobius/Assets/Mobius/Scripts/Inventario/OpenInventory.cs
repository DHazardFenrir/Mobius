using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryCanvas;

    public bool isOpen { get; private set; } = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            inventoryCanvas.SetActive(isOpen);
            SetSettings();
        }
    }

    void SetSettings()
    {
        if (isOpen)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


}
