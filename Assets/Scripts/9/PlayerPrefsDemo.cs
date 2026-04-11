using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1. 保存一个整数
        PlayerPrefs.SetInt("Test", 44);
        PlayerPrefs.Save();
        Debug.Log("已经保存44");
        // 2. 读取整数
        int i= PlayerPrefs.GetInt("Test");
        Debug.Log(i);
        // 3. 修改并再次读取
        PlayerPrefs.SetInt("Test",33);
        int a= PlayerPrefs.GetInt("Test");
        Debug.Log(a);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
