using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    string filepath;
    public List<GameObject> EnemySaves = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        filepath = Application.persistentDataPath + "/save.gamesave";
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filepath, FileMode.Create);

        Save save = new Save();
        save.SaveEnemies(EnemySaves);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(filepath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filepath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        int i = 0;
        foreach (var enemy in save.EnemiesData)
        {
            EnemySaves[i].GetComponent<Enemy>().LoadData(enemy);
            i++;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class Save
    {
        [System.Serializable]
        public struct Vec2
        {
            public float x, y;
            public Vec2(float x, float y)
            {
                this.x = x;
                this.y = y;
                
            }
        }
        [System.Serializable]
        public struct EnemySaveData
        {
            public Vec2 Position;
            public EnemySaveData(Vec2 pos)
            {
                Position = pos;
            }
        }
        public List<EnemySaveData> EnemiesData =
            new List<EnemySaveData>();
        public void SaveEnemies(List<GameObject> enemies)
        {
            foreach (var go in enemies)
            {
                var em = go.GetComponent<Enemy>();

                Vec2 pos = new Vec2(go.transform.position.x, go.transform.position.y);

                EnemiesData.Add(new EnemySaveData(pos));
            }
        }
    }
}
