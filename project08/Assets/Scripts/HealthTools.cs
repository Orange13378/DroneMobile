using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTools : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        DroneController controller = other.GetComponent<DroneController>();
        Bullet Player = other.gameObject.GetComponent<Bullet>();

        if (controller != null)
        {
            Destroy(gameObject);
	        controller.HPadd();
        }
        if (Player != null)
        {
            controller.HPadd();
        }
    }
}
