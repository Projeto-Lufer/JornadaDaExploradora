using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameTransitionsManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePopup;
    [SerializeField] private GameObject endGameFirstButton;
    [SerializeField] private GameObject victoryPopup;
    [SerializeField] private GameObject victoryFirstButton;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject inGameMenuFirstButton;
    [SerializeField] private UnityEngine.EventSystems.EventSystem eventSystem;
    [SerializeField] private PlayerInputManager inputManager;
    private bool gameHasEnded;
    private InGameMenu inGameMenu;
    private DepthOfField dof;

    private void Start()
    {
        Assert.IsNotNull(inGameMenuGameObject);
        inGameMenu = inGameMenuGameObject.GetComponent<InGameMenu>();
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
            SetShowInGameMenu(!inGameMenu.activeInHierarchy);
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
            inGameMenu.SetActive(show);
            eventSystem.SetSelectedGameObject(inGameMenuFirstButton);
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
