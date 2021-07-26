using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColumnas : MonoBehaviour
{
    [SerializeField] Columnas[] columnas;


    [SerializeField] int[] combinaci�n;
    public int[] clave { get; private set; }


    private void Start()
    {
        columnas = FindObjectsOfType<Columnas>();        
    }

    int i = 0;

    public void Clave(int num)
    {
        if (i < clave.Length)
        {
            if (clave[i] == 0)
            {
                clave[i] = num;
            }
            i++;
        }
        else if(i>=clave.Length)
        {
            ComprobarClave();
        }       
    }


    void ComprobarClave()
    {
        if(combinaci�n[0]==clave[0] && combinaci�n[1] == clave[1] && combinaci�n[2] == clave[2] && combinaci�n[3] == clave[3] && combinaci�n[4] == clave[4] && combinaci�n[5] == clave[5])
        {
            
        }
        else
        {
            for (int j = 0; i < clave.Length; i++)
            {
                columnas[j].DesactivarColumna();
                clave[j] = 0;
                i = 0;
            }
            
        }
    }


}