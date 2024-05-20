using UnityEngine;
using System.Collections.Generic;
public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }

    public GameObject bulletPrefab;
    public int initialSize = 120;

    private Queue<GameObject> bullets;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        bullets = new Queue<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bullets.Count == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Enqueue(bullet);
        }

        return bullets.Dequeue();
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }
}