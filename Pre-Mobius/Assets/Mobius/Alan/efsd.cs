using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class efsd : MonoBehaviour
{
    int enemigos;
    GameObject gameOver;


    private void Update()
    {
        if (enemigos <= 0)
            gameOver.SetActive(true);
    }

}
