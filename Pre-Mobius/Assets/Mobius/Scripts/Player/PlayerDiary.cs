using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDiary : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasDiary;
    [SerializeField] private bool canvasTrue;
    [SerializeField] TextMeshProUGUI textEvent;
    [SerializeField] ScriptableEvent eventos;

    private void Start()
    {
        canvasDiary.alpha = 0;
        canvasTrue = false;
    }


    // Update is called once per frame
    void Update()
    {
        ShowDiary();
        HiddenDiary();
    }

    void ShowDiary()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!canvasTrue)
            {
                
                    textEvent.text = eventos.entradaDelDiario;
                
                canvasDiary.alpha = 1;
                canvasTrue = true;

            }


        }
    }

    void HiddenDiary()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canvasTrue)
            {
               
                canvasDiary.alpha = 0;
                    canvasTrue = false;
                
            }
        }
    }
}


