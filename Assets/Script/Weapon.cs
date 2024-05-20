using System.Collections;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public float fireRate = 1f;
    public float bulletSpeed = 10f;
    public int maxAmmo = 10;
    private float lastFireTime = 0;
    public Rigidbody2D playerRb;
    private int ammo;
    bool isReloading = false;
    public TextMeshProUGUI ammoText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        ammo = maxAmmo;
    }

    void Update()
    {
        ammoText.text = ammo + "/" + maxAmmo;

        if (Input.GetMouseButtonDown(0) && Time.time > lastFireTime + 1f / fireRate && ammo > 0 && !isReloading)
        {
            Fire();
            ammo--;
            lastFireTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        for (float t = 0; t < 3; t += Time.deltaTime)
        {
            ammoText.text = "Recargando...";
            yield return null;
        }

        ammo = maxAmmo;
        ammoText.text = ammo + "/" + maxAmmo;

        isReloading = false;
    }

    void Fire()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)bulletSpawnPoint.position).normalized;
            rb.velocity = bulletSpeed * direction;

            Vector2 kickBack = -0.2f * bulletSpeed * direction;
            playerRb.AddForce(kickBack, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody2D component.");
        }
    }
}