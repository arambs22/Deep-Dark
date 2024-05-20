using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player hit enemy");
            Debug.Log("GameManager is: " + gameManager);
            gameManager.PlayerDied(); // Call the PlayerDied method
        }
    }
}