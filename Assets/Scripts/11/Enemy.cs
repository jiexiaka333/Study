using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public Slider healthBarPrefab;
    private Slider healthBarInstance;
    private int currentHealth = 100;

    void Start()
    {
        // 在世界空间 UI 中创建血条（需 Canvas 设置为 World Space）
        Canvas worldCanvas = FindObjectOfType<Canvas>();
        healthBarInstance = Instantiate(healthBarPrefab, worldCanvas.transform);
        healthBarInstance.value = 1;
    }

    void Update()
    {
        // 血条跟随敌人头顶
        //将敌人的头顶位置（世界坐标）转换成屏幕坐标，以便将血条 UI 放置在敌人头顶的正确位置。
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
        healthBarInstance.transform.position = screenPos;

        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //healthBarInstance.value = currentHealth / 100f;
        // 在 TakeDamage 中
        DOTween.To(
    () => healthBarInstance.value,      // 获取当前值的表达式
    x => healthBarInstance.value = x,   // 设置新值的表达式
    currentHealth / 100f,                           // 目标值
    0.2f                                // 动画持续时间（秒）
);
        if (currentHealth <= 0) Destroy(gameObject);
    }
}
