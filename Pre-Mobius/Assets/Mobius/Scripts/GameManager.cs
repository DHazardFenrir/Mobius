using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPaused { get; private set; } = false;
    [SerializeField] GameObject pauseMenu;
    public bool onOtherScreen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !onOtherScreen)
        {
            isPaused = !isPaused;
            Debug.Log(isPaused);
            pauseMenu.SetActive(isPaused);
            Pause();
        }
    }
    #region Pausa
    void Pause()
    {
        if(isPaused)
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            isPaused = true;
            Debug.Log("Esta pausado");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void Resume()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Pause();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion




}
