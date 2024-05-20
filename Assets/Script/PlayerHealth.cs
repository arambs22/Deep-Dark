using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Player has died
            GameManager.Instance.PlayerDied();
        }
    }
}