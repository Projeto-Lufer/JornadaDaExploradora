using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        // Carrega apenas a PoC, mudar quando tiver uma cena inicial
        SceneManager.LoadScene("PoC", LoadSceneMode.Single);
    }

    public void Continue()
    {
        // Por equanto carrega a mesma cena, precisa mudar mais pra frente.
        SceneManager.LoadScene("PoC", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
