using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransitionsManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePopup;
    [SerializeField] private GameObject endGameFirstButton;
    [SerializeField] private GameObject victoryPopup;
    [SerializeField] private GameObject victoryFirstButton;
    [SerializeField] private GameObject inGameMenuGameObject;
    [SerializeField] private UnityEngine.EventSystems.EventSystem eventSystem;
    [SerializeField] private PlayerInputManager inputManager;
    private bool gameHasEnded;
    private InGameMenu inGameMenu;

    private void Start()
    {
        inGameMenu = inGameMenuGameObject.GetComponent<InGameMenu>();
    }

    private void Update()
    {
        if (inputManager.actionEscape.triggered)
        {
            SetShowInGameMenu(!inGameMenuGameObject.activeInHierarchy);
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        SetShowInGameMenu(false);
        endGamePopup.SetActive(true);
        eventSystem.SetSelectedGameObject(endGameFirstButton);
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        SetShowInGameMenu(false);
        gameHasEnded = true;
        victoryPopup.SetActive(true);
        eventSystem.SetSelectedGameObject(victoryFirstButton);
    }

    public void SetShowInGameMenu(bool show)
    {
        if (!gameHasEnded)
        {
            if (show)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            inGameMenuGameObject.SetActive(show);
            inGameMenu.OpenItemsScreen();
        }
    }

    public void RestartFromLastCheckpoint()
    {
        if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        // TODO: Implementar checkpoints
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}