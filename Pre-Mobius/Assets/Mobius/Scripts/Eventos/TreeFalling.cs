using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeFalling : MonoBehaviour
{

    [SerializeField] EventManager eventManager;
    [SerializeField] Animator treeAnimator;
    public TMP_Text textDiary;



 

    private void TreeFall()
    {
        treeAnimator.SetBool("Active", true);
        textDiary.text = "The tree fell";
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Destruible"))
        {
            Debug.Log("Jaja");
            Destroy(other.gameObject);
        }
    }

}
