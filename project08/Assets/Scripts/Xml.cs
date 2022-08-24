using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.IO;

public class Xml : MonoBehaviour
{
    Transform playerTransform;
    void Awake()
    {
        playerTransform = GameObject.Find("Drone").transform;   //добавили трансформ игрока;
    }
    void SaveGame()
    {

        string filepath = "project08/data.xml";
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = null;
        if (!File.Exists(filepath))
        {
            rootNode = xmlDoc.CreateElement("level");
            xmlDoc.AppendChild(rootNode);
        }
        else
        {
            xmlDoc.Load(filepath);
            rootNode = xmlDoc.DocumentElement;
        }

        rootNode.RemoveAll();


        XmlElement elmNew = xmlDoc.CreateElement("player");

        XmlAttribute position_X = xmlDoc.CreateAttribute("position_x");
        position_X.Value = playerTransform.position.x.ToString();
        XmlAttribute position_Y = xmlDoc.CreateAttribute("position_y");
        position_Y.Value = playerTransform.position.y.ToString();
        elmNew.SetAttributeNode(position_X);
        elmNew.SetAttributeNode(position_Y);
        rootNode.AppendChild(elmNew);

        xmlDoc.Save(filepath);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }
}
