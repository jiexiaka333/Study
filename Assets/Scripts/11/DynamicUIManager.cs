using UnityEngine;
using UnityEngine.UI;

public class DynamicUIManager : MonoBehaviour
{
    public Canvas parentCanvas;      // 父画布
    public GameObject textPrefab;    // 文本预制体

    void Start()
    {
        // 动态创建文本
        GameObject newText = Instantiate(textPrefab, parentCanvas.transform);
        Text txt = newText.GetComponent<Text>();
        txt.text = "动态创建的文本";

        // 或直接创建 Image

        //Unity 会在当前场景中生成一个空的 GameObject，名为 DynamicImage。
        GameObject imgObj = new GameObject("DynamicImage");
        imgObj.transform.SetParent(parentCanvas.transform);
        Image img = imgObj.AddComponent<Image>();
        img.color = Color.red;
        // 设置 RectTransform
        RectTransform rect = imgObj.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(100, 100);//宽高

        /*
         anchoredPosition 表示 UI 元素中心点（pivot）相对于锚点（anchors）的偏移量。

new Vector2(200, 200) 表示将物体向右移动 200 像素，向上移动 200 像素（坐标系原点在屏幕左下角或父物体左下角，取决于 Canvas 设置）。
         */
        rect.anchoredPosition = new Vector2(200, 200);
    }
}
