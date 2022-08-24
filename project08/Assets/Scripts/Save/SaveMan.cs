using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.Serialization.Formatters.Binary; 

public class SaveMan : MonoBehaviour
{
    public UnityEvent save;
    public UnityEvent load;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            save.Invoke();
            SaveAll();
        }

        if (Input.GetKeyDown(KeyCode.F7))
        {
            load.Invoke();
            LoadAll();
        }
    }
    public void SaveAll()
    {
        var bases = FindObjectsOfType<SaverBase>();
        foreach (var item in bases)
        {   
            item.Save();
        }
    }
    public void LoadAll()
    {
        var bases = FindObjectsOfType<SaverBase>();
        foreach (var item in bases)
        {   
            item.Load();
        }
    }
}
