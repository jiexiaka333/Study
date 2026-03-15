using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // 获取水平输入（A/D 或 左右箭头）
        float horizontal = Input.GetAxis("Horizontal");
        // 获取垂直输入（W/S 或 上下箭头）
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal, 0, vertical) * 5f;
    }
    // Update is called once per frame
    //void Update()
    //{
       


    //    // 创建一个移动方向向量
    //    //Vector3 move = new Vector3(horizontal, 0, vertical) * Time.deltaTime * 5f;

    //    // 将移动应用到Cube的位置
    //    //transform.Translate(move);


    //    // 旋转部分：用Q/E键旋转
    //    float rotate = 0;
    //    if (Input.GetKey(KeyCode.Q))
    //    {
    //        rotate = -90 * Time.deltaTime;  // 向左转
    //    }
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        rotate = 90 * Time.deltaTime;   // 向右转
    //    }
    //    transform.Rotate(0, rotate, 0);      // 绕Y轴旋转
    //}
}
