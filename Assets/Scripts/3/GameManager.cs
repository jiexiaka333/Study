using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float time=0;
    public static GameManager Instance;
    public int totalCollectibles = 5;//总收集物品数量
    private int collectedCount = 0;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectibleCollected()
    {
        collectedCount++;
        UpdateScoreUI();
        if (collectedCount >= totalCollectibles)
        {
            //胜利
            scoreText.text = "You Win && Time="+time;
        }
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Collected" + collectedCount + "/" + totalCollectibles;
    }
    private void Update()
    {
        time+= Time.deltaTime;
    }


}
