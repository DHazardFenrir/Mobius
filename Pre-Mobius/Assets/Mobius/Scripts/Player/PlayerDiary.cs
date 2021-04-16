using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDiary : MonoBehaviour
{
    [SerializeField] GameObject canvasDiary;
    [SerializeField] private bool canvasTrue;
    

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
            canvasDiary.SetActive(true);
            canvasTrue = true;
        }
    }

    void HiddenDiary()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (canvasDiary)
            {
                
                    canvasDiary.SetActive(false);
                    canvasTrue = false;
                
            }
        }
    }
}


