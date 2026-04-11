using UnityEngine;
using System.IO;

public class SaveSystem_3_28 : MonoBehaviour
{
    private string savePath;

    void Awake()
    {
        savePath= Application.persistentDataPath+"/myJson.json";
    }

    // 公开的保存方法，供 GameManager 调用
    public void SaveGame(GameData_3_28 data)
    {
        try
        {
            string json=JsonUtility.ToJson(data,true);
            File.WriteAllText(savePath, json);
        }
        catch
        {
            Debug.Log("没有保存");
        }
    }

    // 公开的加载方法，供 GameManager 调用
    public GameData_3_28 LoadGame()
    {
        try
        {
            if (File.Exists(savePath))
            {
                string ss=File.ReadAllText(savePath);
                GameData_3_28 gameData_3_28=JsonUtility.FromJson<GameData_3_28>(ss);
                return gameData_3_28;
            }
            else
            {
                Debug.Log("没有存档可读取");
                return new GameData_3_28();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("加载失败：" + e.Message);
            return new GameData_3_28();
        }
      
    }

    // 可选：删除存档的方法
    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("存档已删除");
        }
    }
}
