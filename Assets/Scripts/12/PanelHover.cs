using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHover : MonoBehaviour
{
    private Vector3 originalScale;
    private Tweener currentTweener;

    void Start()
    {
        transform.localScale = Vector3.zero;  // 初始隐藏
    }

    // 显示面板（缩放至1）
    public void ShowPanel()
    {
        // 杀死正在进行的动画，避免冲突
        if (currentTweener != null && currentTweener.IsPlaying())
            currentTweener.Kill();

        currentTweener = transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    // 隐藏面板（缩放至0）
    public void HidePanel()
    {
        if (currentTweener != null && currentTweener.IsPlaying())
            currentTweener.Kill();

        currentTweener = transform.DOScale(0, 0.3f).SetEase(Ease.OutBack);
    }

    // 以下两个方法保留用于鼠标悬停（如果还需要的话）
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    ShowPanel();
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    HidePanel();
    //}
}
