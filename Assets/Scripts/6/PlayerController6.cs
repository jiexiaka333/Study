using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;      // 前后移动速度
    public float rotateSpeed = 100f;  // 旋转速度（度/秒）
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 获取输入
        float h = Input.GetAxis("Horizontal");  // A/D 或 ←/→
        float v = Input.GetAxis("Vertical");    // W/S 或 ↑/↓

        // ===== 1. 旋转（A/D 控制）=====
        if (h != 0)
        {
            // 绕 Y 轴旋转，h 为正时顺时针，为负时逆时针
            transform.Rotate(Vector3.up, h * rotateSpeed * Time.deltaTime);
        }

        // ===== 2. 前后移动（W/S 控制）=====
        if (v != 0)
        {
            // 沿着物体的前方移动（v 为正时向前，为负时向后）
            Vector3 move = transform.forward * v * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.Self);
        }

        // ===== 3. 动画参数 =====
        // 用 v 的绝对值表示移动速度（只关心前后，不管方向）
        float moveSpeedForAnim = Mathf.Abs(v);
        _animator.SetFloat("Speed", moveSpeedForAnim);
    }

    // 动画事件调用的方法
    public void Footstep()
    {
        Debug.Log("👣 脚步声");
    }
}
