using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;


public class SaveBasHP : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public float BaseHealth;
    public float CurrentBaseHP;

    [Multiline(20)]
    public string data;
    public void CollectInfo() // собирает информацию в себя
    {
        BaseHealth = PlayerPrefs.GetFloat("BaseHealth", BaseHealth);
        PlayerPrefs.SetFloat("CurrentBaseHP", BaseHealth);
        position = transform.position;
        rotation = transform.rotation;
        Rigidbody2D rig = GetComponent<Rigidbody2D>();

        if (rig)
        {
            velocity = rig.velocity;
        }
    }

    public void SetInfo() // закидывает информацию из себя
    {
        CurrentBaseHP = PlayerPrefs.GetFloat("CurrentBaseHP", CurrentBaseHP);
        PlayerPrefs.SetFloat("BaseHealth", CurrentBaseHP);
        transform.position = position;
        transform.rotation = rotation;

        Rigidbody2D rig = GetComponent<Rigidbody2D>();

        if (rig)
        {
            rig.velocity = velocity;
        }
    }

        public void Save()
    {
        CollectInfo();
        data = JsonUtility.ToJson(this, true);
        File.WriteAllText(Application.dataPath + "/Save/Base/save.txt", data);
    }
    
        public void Load()
    {
        data = File.ReadAllText(Application.dataPath + "/Save/Base/save.txt");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
    }
}