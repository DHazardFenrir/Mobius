using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColumnas : MonoBehaviour
{
    [SerializeField] Columnas[] columnas;


    [SerializeField] int[] combinación;
    public int[] clave;


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
            if (i == clave.Length)
            {
                Debug.Log("Comprobar clave");
                ComprobarClave();
            }
            Debug.Log(i);
        }
            
    }

    public void ResetearClave()
    {
        for(int i=0;i<clave.Length;i++ )
        {
            clave[i] = 0;
        }
        i = 0;
    }

    [SerializeField]Animator altarAnim;

    [SerializeField]GameObject altar;

    void ComprobarClave()
    {
        Debug.Log("Comprobando");
        if(combinación[0]==clave[0] && combinación[1] == clave[1] && combinación[2] == clave[2] && combinación[3] == clave[3] && combinación[4] == clave[4] && combinación[5] == clave[5])
        {
            altar.GetComponent<BoxCollider>().enabled = true;
            altarAnim.SetBool("Abierto", true);
            Debug.Log("Jala");
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
