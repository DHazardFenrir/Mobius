using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menuGO;
    [SerializeField] GameObject creditosGO;
    [SerializeField] GameObject controlesGO;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Creditos()
    {
        menuGO.SetActive(false);
        creditosGO.SetActive(true);
        controlesGO.SetActive(false);
    }

    public void Controles()
    {
        menuGO.SetActive(false);
        creditosGO.SetActive(false);
        controlesGO.SetActive(true);
    }

    public void Back()
    {
        menuGO.SetActive(true);
        creditosGO.SetActive(false);
        controlesGO.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
    }


}
