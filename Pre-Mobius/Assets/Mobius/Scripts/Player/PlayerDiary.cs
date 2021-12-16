using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDiary : MonoBehaviour
{
    
    public TMP_Text textEvent;
    [SerializeField] ScriptableEvent eventos;

    [SerializeField] GameObject diaryCanvas;
    GameManager gm;

    public bool isOpen { get; private set; } = false;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }
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
            gm.OnUI();
            Time.timeScale = 0;
            
        }
        else
        {
            gm.OnUI();
            Time.timeScale = 1;
        }
    }
}


