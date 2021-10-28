using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPaused { get; private set; } = false;
    [SerializeField] GameObject pauseMenu;
    public bool onOtherScreen;

    [SerializeField] bool[] puzzle;
    [SerializeField] GameObject luzFinal;


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
            luzFinal.SetActive(true);
            GameOver();
        }

    }

    private void Start()
    {
        
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
            luzFinal.SetActive(true);
            //StartCoroutine(GameOverScreen());
        }
    }

    public IEnumerator GameOverScreen()
    {
        gameOverCanvasGroup.DOFade(1f, 8f);
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
    }

    public void puzzleFinished(int num)
    {
        puzzle[num] = true;
        GameOver();
    }

    #endregion


    public GameObject itemToDestroy;
    public void DestroyItem()
    {
        if(itemToDestroy!=null)
        {
        Destroy(itemToDestroy);
        Debug.Log("ItemDestroyed");
        }
    }

    public Text descriptionText;
    [SerializeField] GameObject inspectCanvas;
    [SerializeField] GameObject inventoryCanvas;
    [SerializeField] GameObject inspectCamera;

    public void Back()
    {
        descriptionText.text = " ";
        inspectCanvas.SetActive(false);
        inspectCamera.GetComponent<Camera>().enabled = false;
        inventoryCanvas.SetActive(true);


    }

}
