using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameTransitionsManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePopup;
    [SerializeField] private GameObject endGameFirstButton;
    [SerializeField] private GameObject victoryPopup;
    [SerializeField] private GameObject victoryFirstButton;
    [SerializeField] private GameObject inGameMenuGameObject;
    [SerializeField] private UnityEngine.EventSystems.EventSystem eventSystem;
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private Volume postProcessingVolume;

    private bool gameHasEnded;
    private InGameMenu inGameMenu;
    private DepthOfField dof;

    private void Start()
    {
        inGameMenu = inGameMenuGameObject.GetComponent<InGameMenu>();
        Assert.IsNotNull(inGameMenuGameObject);
        if (!dof)
        {
            DepthOfField tempDof;

            if (postProcessingVolume.profile.TryGet(out tempDof))
            {
                dof = tempDof;
            }
        }
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
        dof.active = false;
        SetShowInGameMenu(false);
        endGamePopup.SetActive(true);
        eventSystem.SetSelectedGameObject(endGameFirstButton);
    }

    public void WinGame()
    {
        dof.active = true;
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
                inGameMenu.OpenItemsScreen();
            }
            else
            {
                Time.timeScale = 1;
            }

            dof.active = show;
            inGameMenuGameObject.SetActive(show);
        }
    }

    public void RestartFromLastCheckpoint()
    {
        if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
            dof.active = false;
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