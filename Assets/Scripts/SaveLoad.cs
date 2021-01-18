using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" + "Savegame.dat");
        SaveManagement save = new SaveManagement();
        save.scor = GetComponent<Player>().highPoint;
 
        binary.Serialize(file, save);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/" + "Savegame.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" + "Savegame.dat", FileMode.Open);
            SaveManagement save = (SaveManagement)binary.Deserialize(file);
            file.Close();
            GetComponent<Player>().highPoint = save.scor;
          
        }

    }
}

[Serializable]
public class SaveManagement
{
    public int scor;
   
}
