using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public string fileName = "GameData.xml";
    private GameData data = new GameData();
    
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/" + fileName;
        Load(path);
    }

    public void Load(string path)
    {
        
    }

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(GameData));
        // LIFE IS A HIGH WAAYYYYY
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, data);
        stream.Close();
        Debug.Log("File Saved Successfully to " + path);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            player = FindObjectOfType<PlayerScript>().transform;
            data.position = player.position;
            data.rotation = player.rotation;
            data.dialogue = new string[]
            {
                "Hello",
                "Word"
            };
            Save(Application.dataPath + "/" + fileName);
        }
    }
}
