using UnityEngine;

public class GameManager_9 : MonoBehaviour
{
    // 单例模式，方便其他脚本访问
    public static GameManager_9 Instance;

    [Header("组件引用")]
    public SaveSystem saveSystem;
    public GameObject player;

    [Header("游戏数据")]
    public int playerScore = 0;
    public int playerHealth = 100;
    public int currentLevel = 1;

    // 事件，用于通知其他脚本数据已加载
    public System.Action OnGameLoaded;

    void Awake()
    {
        // 单例设置
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 切换场景不销毁
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 获取 SaveSystem
        if (saveSystem == null)
            saveSystem = GetComponent<SaveSystem>();

        if (saveSystem == null)
        {
            Debug.LogWarning("未找到 SaveSystem，创建新的");
            saveSystem = gameObject.AddComponent<SaveSystem>();
        }
    }

    void Start()
    {
        // 如果有玩家引用，自动加载存档
        if (player != null)
        {
            LoadGame();
        }
    }

    void Update()
    {
        // 统一使用 K 键保存，L 键加载
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        GameData data = new GameData();

        // 收集游戏数据
        if (player != null)
            data.playerPosition = player.transform.position;

        data.playerScore = playerScore;
        data.playerHealth = playerHealth;
        data.currentLevel = currentLevel;

        // 获取火焰状态（从 PlayerController）
        PlayerController playerController = player?.GetComponent<PlayerController>();
        if (playerController != null)
        {
            data.flameActive = playerController.IsFlameActive();
        }

        // 保存
        saveSystem.SaveGame(data);
        Debug.Log($"游戏已保存: 分数 {playerScore}, 血量 {playerHealth}, 关卡 {currentLevel}");
    }

    public void LoadGame()
    {
        GameData data = saveSystem.LoadGame();

        // 应用游戏数据
        if (player != null)
            player.transform.position = data.playerPosition;

        playerScore = data.playerScore;
        playerHealth = data.playerHealth;
        currentLevel = data.currentLevel;

        // 恢复火焰状态
        PlayerController playerController = player?.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetFlameActive(data.flameActive);
        }

        // 触发加载完成事件，通知其他脚本
        OnGameLoaded?.Invoke();

        Debug.Log($"游戏已加载: 分数 {playerScore}, 血量 {playerHealth}, 关卡 {currentLevel}");
    }

    // 加分方法（示例）
    public void AddScore(int amount)
    {
        playerScore += amount;
        Debug.Log($"当前分数: {playerScore}");
    }

    // 扣血方法（示例）
    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("游戏结束");
        }
    }
}
