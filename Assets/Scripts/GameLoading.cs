using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameLoading : MonoBehaviour {
    public static bool saved = false;
    // public static GameObject[] allSaveObject;
    // public GameObject parent = null;

    private string readJson(string filename) {
        FileStream fs = new FileStream(filename, FileMode.Open);
        byte[] bytes = new byte[4096];
        int count = (int) fs.Length;
        fs.Read(bytes, 0, count);
        string str = new UTF8Encoding().GetString(bytes);
        fs.Close();
        return str;
    }

    private void writeJson(string filename, string jsonString) {
        FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
        byte[] bytes =  Encoding.UTF8.GetBytes(jsonString);
        fs.Write(bytes, 0, bytes.Length);
        fs.Flush();
        fs.Close();
    }

    private void Start() {
        // foreach (GameObject current in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {
        //     if (current.name == "Canvas") continue;
        //     print(current.name);
        //     // if (saved) current.GetComponent<LoadState>().load();
        //     // else current.AddComponent<LoadState>();
        // }
        // // allSaveObject = new ArrayList<string>();
    }

    public static void saveAll() {
        // saved = true;
        // foreach (GameObject temp in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {
        //     GameObject current = temp.gameObject;
        //     if (current.name == "Canvas") continue;
        //     // current.GetComponent<LoadState>().save();
        // }
    }
 
}
