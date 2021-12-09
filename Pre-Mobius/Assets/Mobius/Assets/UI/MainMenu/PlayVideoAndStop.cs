using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class PlayVideoAndStop : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private AudioSource audio;
    [SerializeField]private float fadeVelocity;
    
    [SerializeField]private float volumeRampSpeed;
    void Awake()
    {
        audio = FindObjectOfType<AudioSource>();
        video = GetComponent<VideoPlayer>();
        video.Play();
       
        video.loopPointReached += GoToGame;
    }

    void GoToGame(VideoPlayer vp)
    {
        videoPlayer.gameObject.SetActive(false);
        audio.volume = 0.2f;
        SceneManager.LoadScene(1);
    }
    
}
