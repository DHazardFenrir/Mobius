using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using TMPro;

public class Transition : MonoBehaviour
{
    [SerializeField] private CanvasGroup transition;
    [SerializeField] public TMP_Text txt;
    [SerializeField] private AreaName objText;
    private Tween fadeTween;


    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entro Player");
            txt.text = objText.nombre;
            Debug.Log(objText.nombre);
            StartCoroutine(Fading());
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            txt.text = "";
            StopCoroutine(Fading());
        }
    }

    private void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            transition.interactable = false;
            transition.blocksRaycasts = false;
        });
    }

    private void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            transition.interactable = false;
            transition.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = transition.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator Fading()
    {
        yield return new WaitForSeconds(0.1f);
        FadeIn(0.2f);
        yield return new WaitForSeconds(0.4f);
        FadeOut(0.3f);
    }
}
