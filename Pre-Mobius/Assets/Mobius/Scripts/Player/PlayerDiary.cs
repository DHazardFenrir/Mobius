using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDiary : MonoBehaviour
{
    
    public TextMeshProUGUI textEvent;
    [SerializeField] ScriptableEvent eventos;

    [SerializeField] GameObject diaryCanvas;

    public bool isOpen { get; private set; } = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isOpen = !isOpen;
            diaryCanvas.SetActive(isOpen);
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


