using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchweapon : MonoBehaviour
{
    public int s;
    [SerializeField] protected GameObject Auto, Drob, Snipe;
    void Start()
    {
        s = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchWeapon()
    {
        switch (s)
        {
            case 1:
                Auto.SetActive(false);
                Drob.SetActive(true);
                break;

            case 2:
                Drob.SetActive(false);
                Snipe.SetActive(true);
                break;

            case 3:
                Snipe.SetActive(false);
                Auto.SetActive(true);
                s = 0;
                break;
        }
    }
    public void Pluss()
    {
        s++;
    }
}
