using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DeathScreen deathScreen;
    public static GameManager Instance { get; private set; }
    public int score;
    private int hitCount = 0;
    public TextMeshProUGUI scoreText; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void PlayerDied()
    {
        Debug.Log("PlayerDied called");
        Debug.Log("DeathScreen is: " + deathScreen);
        // Activate the death screen UI
        deathScreen.deathScreenUI.SetActive(true);
    }
    public void Retry()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}