using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        // Aquí debes cargar la escena de tu menú principal. Asegúrate de que "Menu" sea el nombre de tu escena de menú.
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}