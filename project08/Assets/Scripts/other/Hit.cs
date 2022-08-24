using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private Rigidbody2D rb;
    static string tagPlayer = "Base";
    private Transform player;
    public float speed = 5f;
    public int damage = 1;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(tagPlayer).GetComponent<Transform>();
        target = new Vector2(player.position.x, player.position.y);
    }
    
     private void OnTriggerEnter2D(Collider2D other)
    {
        DroneController controller = other.GetComponent<DroneController>();

        if (controller != null)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
