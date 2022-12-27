using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MainManager : MonoBehaviour
{

    //Ejercicio para pasar el color de una escena a otra
    public Color teamColor; //variable

    //PATRÓN SINGLETON - EJERCICIO PASAR DARA ENTRE ESCENAS
    public static MainManager Instance;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //AGREGADO EN EL EJERCICIO DATA ENTRE SESIONES
        LoadColor();

    }


    //EJERCICIO GUARDAR DATA ENTRE SESIONES 
    //https://docs.unity3d.com/Manual/JSONSerialization.html

    [System.Serializable]
    class SaveData
    {
        public Color teamColorOfTheClass;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColorOfTheClass = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        //using System.IO;
        //https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.teamColorOfTheClass;
        }
    }


}
