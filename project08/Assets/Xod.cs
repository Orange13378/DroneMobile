using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Xod : MonoBehaviour
{
    Rigidbody2D rb;
    float dirx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        dirx = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx * 5, 0);
    }
}