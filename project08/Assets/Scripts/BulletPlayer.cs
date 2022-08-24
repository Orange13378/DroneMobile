using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public int damage = 1;
    private Rigidbody2D rb;
    private float startTimeUndoShoots = 3f;
    private float timeUndoShoots = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        if (timeUndoShoots <= 0)
        {
            DestroyImmediate(gameObject);
            timeUndoShoots = startTimeUndoShoots;
        }
        else
        {
            timeUndoShoots -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Bullet Player = hitInfo.gameObject.GetComponent<Bullet>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.CompareTag("Stena"))
        {
            Destroy(gameObject);
        }
        if (hitInfo.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }
}