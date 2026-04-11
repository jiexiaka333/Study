using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GridLayoutGroup gird1;

    public GameObject image;
    void Start()
    {
       
       for (int i = 0;i<3;i++)
        {
            GameObject gb = Instantiate(image,gird1.transform);
            if(i == 0)
            {
                gb.GetComponentInChildren<Text>().text = "开始游戏";
            }
            if(i == 1)
            {
                gb.GetComponentInChildren<Text>().text = "设置";
            }
            if(i == 2)
            {
                gb.GetComponentInChildren<Text>().text = "退出";
            }
        }
      
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
