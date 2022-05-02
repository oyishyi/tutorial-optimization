using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    private void Awake() {
        if (GameManager.Instance != null) {
            Destroy(gameObject);
            return;
        }
        GameManager.Instance = this;
        DontDestroyOnLoad(gameObject);
        // º”‘ÿ¥Êµµ
        GameManager.Instance.LoadColor();
    }
    public Color TeamColor;

    [System.Serializable]
    private class SaveData {
        public Color TeamColor;
    }

    public void SaveColor() {
        SaveData saveData = new SaveData();
        saveData.TeamColor = GameManager.Instance.TeamColor;

        string saveDataJsonString = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", saveDataJsonString);
    }

    public void LoadColor() {
        string saveFilePath = Application.persistentDataPath + "/saveData.json";

        if (File.Exists(saveFilePath)) {
            string saveDataString = File.ReadAllText(saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataString);
            GameManager.Instance.TeamColor = saveData.TeamColor;
        }
    }
}


