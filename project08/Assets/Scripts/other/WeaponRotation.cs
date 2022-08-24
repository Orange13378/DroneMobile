using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
     [SerializeField] protected VariableJoystick joystick1;
    void Start()
    {
        joystick1 = FindObjectOfType<VariableJoystick>();
        
    }

    void Update()
    {
         if (joystick1.Horizontal < 0)
        {
            Debug.Log("rotation");
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
