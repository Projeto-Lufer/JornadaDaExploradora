using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        // Carrega a cena Main
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Continue()
    {
        // Por equanto carrega a mesma cena, precisa mudar mais pra frente.
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
