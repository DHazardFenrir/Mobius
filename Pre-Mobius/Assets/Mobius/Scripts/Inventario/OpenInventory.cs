using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryCanvas;
    GameManager gm;

    public bool isOpen { get; private set; } = false;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !gm.isPaused)
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
            gm.onOtherScreen = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gm.onOtherScreen = false;
        }
    }


}
