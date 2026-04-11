using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // 重要：引入 UI 命名空间

public class UIFadeEffect : MonoBehaviour
{
    public Image image;  // 改成 Image，不是 SpriteRenderer

    void Start()
    {
        StartFade(3f);
    }

    public void StartFade(float duration)
    {
        StartCoroutine(FadeCoroutine(duration));
    }

    IEnumerator FadeCoroutine(float duration)
    {
        Color startColor = image.color;  // Image 也有 color 属性
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            image.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
        image.color = targetColor;
    }
}
