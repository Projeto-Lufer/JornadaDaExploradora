using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransitionsManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePopup;
    [SerializeField] private GameObject inGameMenu;

    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            SetShowInGameMenu(!inGameMenu.activeInHierarchy);
        }
    }

    public void EndGame()
    {
        SetShowInGameMenu(false);
        endGamePopup.SetActive(true);
    }

    public void SetShowInGameMenu(bool show)
    {
        inGameMenu.SetActive(show);
    }

    public void RestartFromLastCheckpoint()
    {
        // TODO: Implementar checkpoints
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
