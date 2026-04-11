using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    // 存档路径
    private string savePath;

    void Awake()
    {
        // Application.persistentDataPath 是各平台推荐的数据存储路径
        // Windows: C:\Users\用户名\AppData\LocalLow\公司名\游戏名\
        // Android/iOS: 应用私有目录
        savePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        Debug.Log("存档路径: " + savePath);
    }

    // 保存游戏
    public void SaveGame(GameData data)
    {
        try
        {
            // 将数据对象转换为 JSON 字符串
            string json = JsonUtility.ToJson(data, true); // true = 格式化输出（易读）

            // 写入文件
            File.WriteAllText(savePath, json);

            Debug.Log("游戏已保存: " + savePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("保存失败: " + e.Message);
        }
    }

    // 加载游戏
    public GameData LoadGame()
    {
        try
        {
            // 检查存档是否存在
            if (File.Exists(savePath))
            {
                // 读取 JSON 字符串
                string json = File.ReadAllText(savePath);

                // 转换为数据对象
                GameData data = JsonUtility.FromJson<GameData>(json);

                Debug.Log("游戏已加载");
                return data;
            }
            else
            {
                Debug.Log("没有找到存档，创建新存档");
                return new GameData(); // 返回默认数据
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("加载失败: " + e.Message);
            return new GameData();
        }
    }

    // 删除存档
    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("存档已删除");
        }
    }
}
