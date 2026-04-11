using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource ad;
    private bool gameStarted = false;

    private void Start()
    {
        ad = GetComponent<AudioSource>();
        gameObject.tag = "Collectible";

        if (ad == null)
        {
            ad = gameObject.AddComponent<AudioSource>();
        }

        // 延迟0.5秒后才能收集
        Invoke("EnableCollection", 0.5f);

        Debug.Log($"收集物 {gameObject.name} 初始化完成");
    }

    private void EnableCollection()
    {
        gameStarted = true;
        Debug.Log($"收集物 {gameObject.name} 现在可以被收集了");
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. 检查游戏是否已经开始
        if (!gameStarted) return;

        // 2. 忽略自己和自己
        if (other.gameObject == this.gameObject) return;

        // 3. 忽略父子关系
        if (other.gameObject.transform.IsChildOf(transform) || transform.IsChildOf(other.transform)) return;

        // 4. 忽略其他收集物
        if (other.CompareTag("Collectible")) return;

        // 5. 只处理玩家
        if (other.CompareTag("Player"))
        {
            Debug.Log($"玩家 {other.gameObject.name} 碰到了收集物 {gameObject.name}");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.CollectibleCollected();
            }

            if (ad != null && ad.clip != null)
            {
                ad.Play();
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                Destroy(gameObject, ad.clip.length);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}