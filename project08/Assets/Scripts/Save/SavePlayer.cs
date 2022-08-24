using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;


public class SavePlayer : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public float PlayerHealth;
    public float CurrentHP;

    [Multiline(20)]
    public string data;
    public void CollectInfo() // собирает информацию в себя
    {
        PlayerHealth = PlayerPrefs.GetFloat("PlayerHealth", PlayerHealth);
        PlayerPrefs.SetFloat("CurrentHP", PlayerHealth);
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
        CurrentHP = PlayerPrefs.GetFloat("CurrentHP", CurrentHP);
        PlayerPrefs.SetFloat("PlayerHealth", CurrentHP);
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
        File.WriteAllText(Application.dataPath + "/Save/Player/save.txt", data);
    }

        public void Load()
    {   
        data = File.ReadAllText(Application.dataPath + "/Save/Player/save.txt");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
    }
}