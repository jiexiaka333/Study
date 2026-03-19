using UnityEngine;

public class PlayerMover5 : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 获取键盘输入
        float moveX = Input.GetAxis("Horizontal"); // A/D 或 ←/→
        float moveZ = Input.GetAxis("Vertical");   // W/S 或 ↑/↓

        // 计算移动方向
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;

        // 移动物体
        transform.Translate(move, Space.World);
    }
}
