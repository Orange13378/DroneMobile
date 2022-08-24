using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splashsc : MonoBehaviour
{
    [SerializeField] private float timeBtwShoots = 0.2f;
    [SerializeField] private float startTimeBtwShots = 1;
    public Rigidbody2D rb;
    private Transform player;
    public int damage = 1;
    private Vector2 target;

    private void OnTriggerStay2D(Collider2D other)
    {
        Base controller = other.GetComponent<Base>();

        if (controller != null)
        {
            if (timeBtwShoots <= 0)
            {
                controller.TakeDamage(damage);
                DestroyBullet();
                timeBtwShoots = startTimeBtwShots;
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
        void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}