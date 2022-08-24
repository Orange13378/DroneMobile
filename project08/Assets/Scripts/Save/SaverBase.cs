using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;


public class SaverBase : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public float health;
    public float CurrentEnemyHP;

    [Multiline(20)]
    public string data;

    [Multiline(20)]
    public string Hp;
    public void CollectInfo() // собирает информацию в себя
    {
        health = PlayerPrefs.GetFloat("EnemyHealth", health);
        PlayerPrefs.SetFloat("CurrentEnemyHP", health);

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
        CurrentEnemyHP = PlayerPrefs.GetFloat("CurrentEnemyHP", CurrentEnemyHP);
        PlayerPrefs.SetFloat("CurrentEnemyHP", CurrentEnemyHP);
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
        File.WriteAllText(Application.dataPath + "/Save/Enemy/save.txt" + gameObject.GetInstanceID() + ".TXT", data);
    }

        public void Load()
    {   
        data = File.ReadAllText(Application.dataPath + "/Save/Enemy/save.txt" + gameObject.GetInstanceID() + ".TXT");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
    }
}