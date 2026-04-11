using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData_3_28 
{
    // 思考：你需要保存哪些数据？
    public Vector3 playerPosition;
    public int playerScore;

    // 动手任务：添加两个新字段
    // 1. 玩家的血量（int）
    // 2. 当前关卡编号（int）
    public int hp;
    public int level;

    public GameData_3_28()
    {
        playerPosition = Vector3.zero;
        playerScore = 0;
        // 在这里初始化你添加的字段
        hp = 100;
        level = 0;
    }
}
