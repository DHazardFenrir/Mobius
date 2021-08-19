using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public bool isPaused { get; private set; } = false;
    [SerializeField] GameObject pauseMenu;
    public bool onOtherScreen;


    [SerializeField] bool[] puzzle;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !onOtherScreen)
        {
            isPaused = !isPaused;
            Debug.Log(isPaused);
            pauseMenu.SetActive(isPaused);
            Pause();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            GameOver();
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

    #region EndGame

    [SerializeField] CanvasGroup gameOverCanvasGroup;

    public void GameOver()
    {
        if(puzzle[0] && puzzle[1] && puzzle[2])
        {
            StartCoroutine(GameOverScreen());
        }
    }

    IEnumerator GameOverScreen()
    {
        gameOverCanvasGroup.DOFade(1f, 2f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }

    public void puzzleFinished(int num)
    {
        puzzle[num] = true;
    }

    #endregion

    public void DestroyItem(GameObject itemToDestroy)
    {
        Destroy(itemToDestroy);
    }

}
