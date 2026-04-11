using UnityEngine;
using UnityEngine.UI;   // 注意：只需要这一个UI命名空间，删除 UnityEngine.UIElements

public class Manner : MonoBehaviour
{
    public Button button1;           // 拖入你的按钮
    public Button button2;

    public PanelHover panelHover;   // 拖入挂有 PanelHover 的面板物体

    void Start()
    {
        // 点击按钮时显示面板
        button1.onClick.AddListener(() => {
            panelHover.ShowPanel();
        });
        button2.onClick.AddListener(() => {
            panelHover.HidePanel();
        });
    }
}
