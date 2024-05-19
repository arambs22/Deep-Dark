using UnityEngine;
using TMPro; // Import TextMeshPro
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public int Respawn;
    public TextMeshProUGUI youDiedText; // Reference to the "YOU DIED" text object

    // Start is called before the first frame update
    void Start()
    {
        youDiedText.gameObject.SetActive(false); // Make sure the text is hidden at the start
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            youDiedText.gameObject.SetActive(true); // Show the "YOU DIED" text
            Invoke("RespawnPlayer", 0); // Wait for 2 seconds before respawning
        }
    }

    void RespawnPlayer()
    {
        youDiedText.gameObject.SetActive(false); // Hide the "YOU DIED" text
        SceneManager.LoadScene(Respawn);
    }
}