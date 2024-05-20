using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aumenta la puntuación en 100
        GameManager.Instance.IncreaseScore(100);

        // Destruye el enemigo
        Destroy(gameObject);
    }
}