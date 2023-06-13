using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 20.0f;  // This is now twice the original speed
    public float acceleration = 15f;  // This is the acceleration when a key is pressed
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Log input values
        Debug.Log("Input - Horizontal: " + moveHorizontal + ", Vertical: " + moveVertical);

        // The player accelerates when a key is pressed and gradually slows down when the key is released
        Vector2 targetVelocity = new Vector2(moveHorizontal * maxSpeed, moveVertical * maxSpeed);
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, acceleration * Time.deltaTime);

        // Log new position values
        Debug.Log("New Position - X: " + transform.position.x + ", Y: " + transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Create new bullet GameObject
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.up * 18f;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy player object
            Destroy(gameObject);

            // Call the game over method
            GameManager.Instance.GameOver();
        }
    }
}
