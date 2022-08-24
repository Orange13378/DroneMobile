using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : LevelController
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Xod player = other.GetComponent<Xod>();
        DroneController controller = other.GetComponent<DroneController>();
        if (controller != null | player != null)
        {
            isEndGame();
        }
    }
}