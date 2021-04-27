using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransitionsManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePopup;

    public void EndGame()
    {
        endGamePopup.SetActive(true);
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
