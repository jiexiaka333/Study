using UnityEngine;

public class GameManager_3_28 : MonoBehaviour
{
    public GameObject player;
    private SaveSystem_3_28 saveSystem;

    public int currentScore=0;
    public int currentHealth = 0;

    void Start()
    {
        saveSystem = GetComponent<SaveSystem_3_28>();
        LoadGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) SaveGame();
        if (Input.GetKeyDown(KeyCode.L)) LoadGame();

        // 测试用：按 P 键加分，方便测试存档功能
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentScore += 10;
            Debug.Log($"当前分数：{currentScore}");
        }

        // 测试用：按 H 键扣血
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHealth -= 10;
            Debug.Log($"当前血量：{currentHealth}");
        }
    }

    void SaveGame()
    {
        GameData_3_28 data = new GameData_3_28();
        data.playerPosition = player.transform.position;
        data.hp = currentHealth;
        data.playerScore= currentScore;
        saveSystem.SaveGame(data);

        Debug.Log("已经成功存储");
    }

    void LoadGame()
    {
        GameData_3_28 gameData = saveSystem.LoadGame();
        if (player != null)
        {
            player.transform.position = gameData.playerPosition;  // 恢复位置
        }
        currentHealth = gameData.hp;
        currentScore = gameData.playerScore;

        Debug.Log($"加载成功！位置：{gameData.playerPosition}，血量：{currentHealth}，分数：{currentScore}");
    }
}
