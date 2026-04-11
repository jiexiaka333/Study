using UnityEngine;
using System.Collections;

public class CoroutineDemo : MonoBehaviour
{
    void Start()
    {
        // 启动协程
        StartCoroutine(MyCoroutine());
        StartCoroutine(WaitFrames());
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("协程开始：" + Time.time);
        yield return new WaitForSeconds(2f);  // 等待2秒
        Debug.Log("协程继续：" + Time.time);
    }
    IEnumerator WaitFrames()
    {
        Debug.Log("等待前");
        yield return null;  // 等待一帧
        Debug.Log("等待一帧后");
        yield return new WaitForSeconds(1f);  // 等待1秒
        Debug.Log("等待1秒后");
    }
}
