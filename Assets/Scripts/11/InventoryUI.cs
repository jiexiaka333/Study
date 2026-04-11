using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;
    public GridLayoutGroup grid;

    void Start()
    {
        // 生成 3x3 格子
        for (int i = 0; i < 9; i++)
        {
            GameObject slot = Instantiate(slotPrefab, grid.transform);
            slot.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
