using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;

    public void TryAgain()
    {
        // Aquí debes cargar la escena de tu nivel actual. Asegúrate de que "Level" sea el nombre de tu escena de nivel.
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        // Aquí debes cargar la escena de tu menú principal. Asegúrate de que "Menu" sea el nombre de tu escena de menú.
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}