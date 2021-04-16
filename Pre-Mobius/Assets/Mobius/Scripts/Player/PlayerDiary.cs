using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDiary : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasDiary;
    [SerializeField] private bool canvasTrue;

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
                Debug.Log("FFFFFFF");
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
                Debug.Log("GGGGGGGGGG");
                canvasDiary.alpha = 0;
                    canvasTrue = false;
                
            }
        }
    }
}


