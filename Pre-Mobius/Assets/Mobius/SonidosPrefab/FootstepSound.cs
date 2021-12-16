using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;

public class FootstepSound : MonoBehaviour
{
    [SerializeField] private RigidbodyFirstPersonController rb;
    [SerializeField] private AudioSource audio;
    [SerializeField] private Animator anim;
    [SerializeField] private GameManager gm;

    private void Awake()
    {
        rb = GetComponent<RigidbodyFirstPersonController>();
        anim = GetComponent<Animator>();
        
    }



    // Update is called once per frame
    void Update()
    {
        PlaySoundFootsteps();
    }

    void PlaySoundFootsteps()
    {
        if (rb.Grounded == true && audio.isPlaying == false && rb.Velocity.magnitude > 2f)
        {
            audio.volume = Random.Range(0.8f, 1);
            audio.pitch = Random.Range(0.8f, 1.1f);

            audio.Play();
        }
        else if (rb.Grounded == true && audio.isPlaying == true && rb.Velocity.magnitude <= 1f)
        {
            audio.Stop();
        }
        if (anim.isActiveAndEnabled)
        {
            audio.Stop();

        }

        if (gm.isPaused)
        {
            audio.Stop();
        }
        
    }
}
