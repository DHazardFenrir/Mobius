using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFalling : MonoBehaviour
{

    [SerializeField] EventManager eventManager;
    [SerializeField] Animator treeAnimator;



    private void OnEnable()
    {
        eventManager.TreeFallEvent+=TreeFall;
    }

    private void TreeFall()
    {
        treeAnimator.SetBool("Active", true);
    }

}
