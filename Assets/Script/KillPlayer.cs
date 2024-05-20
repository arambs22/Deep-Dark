using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public int Respawn;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("RespawnPlayer", 0); // Wait for 2 seconds before respawning
        }
    }

    void RespawnPlayer()
    {
        SceneManager.LoadScene(Respawn);
    }
}