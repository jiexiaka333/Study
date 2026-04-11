using System.Collections;
using UnityEngine;

public class CoroutineControl : MonoBehaviour
{
    private Coroutine myCoroutine;  // 保存协程的引用^指向协程的引用
                                    // Coroutine 是 Unity 中的一个类（Class），用于引用一个正在运行的协程。
    public GameObject gameObject;
    void Start()
    {
        // 启动协程，并保存引用
        //myCoroutine = StartCoroutine(MyLoop());
        //StartCoroutine(ParentCoroutine());
        StartCoroutine(Fz(gameObject));
    }

    void Update()
    {
        //// 按 S 键停止协程
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    StopCoroutineExample();
        //}

        //// 按 R 键重新启动协程
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    RestartCoroutine();
        //}
    }
    IEnumerator Fz(GameObject gameObject)
    {
        int i = 0;
        for (i = 0;i<5;i++)
        {
            yield return new WaitForSeconds(2);
            Instantiate(gameObject);
        }
       
    }
    // MyLoop 协程：无限循环，每帧输出一次
    IEnumerator MyLoop()
    {
        int count = 0;
        while (true)  // 无限循环
        {
            count++;
            Debug.Log($"协程运行中... 第 {count} 次");
            yield return null;  // 每帧执行一次
        }
    }

    IEnumerator ParentCoroutine()
    {
        Debug.Log("父协程开始");
        yield return StartCoroutine(ChildCoroutine());
        Debug.Log("父协程继续");
    }

    IEnumerator ChildCoroutine()
    {
        Debug.Log("子协程开始");
        yield return new WaitForSeconds(1f);
        Debug.Log("子协程结束");
    }

    void StopCoroutineExample()
    {
        if (myCoroutine != null)
        {
            StopCoroutine(myCoroutine);
            Debug.Log("协程已停止");
            myCoroutine = null;  // 清空引用
        }
        else
        {
            Debug.Log("协程未运行");
        }
    }

    void RestartCoroutine()
    {
        // 先停止正在运行的（如果有）
        if (myCoroutine != null)
        {
            StopCoroutine(myCoroutine);
        }
        // 重新启动
        myCoroutine = StartCoroutine(MyLoop());
        Debug.Log("协程已重新启动");
    }
}
