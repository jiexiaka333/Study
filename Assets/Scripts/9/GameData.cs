using System;
using UnityEngine;

[Serializable]
public class GameData
{
    // 玩家数据
    public Vector3 playerPosition;
    public int playerScore;
    public int playerHealth;
    public bool flameActive;

    // 游戏进度
    public int currentLevel;
    public float playTime;

    // 构造函数，初始化默认值
    public GameData()
    {
        playerPosition = Vector3.zero;
        playerScore = 0;
        playerHealth = 100;
        flameActive = false;
        currentLevel = 1;
        playTime = 0f;
    }
}
