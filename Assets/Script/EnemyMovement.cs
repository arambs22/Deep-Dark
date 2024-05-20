using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float followRange = 5.0f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < followRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
}