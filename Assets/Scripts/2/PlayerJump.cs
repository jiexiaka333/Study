using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 5f;  // 跳跃力度，可在Inspector调整

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 检测空格键按下（GetKeyDown表示按下的一瞬间）
        if (Input.GetKeyDown(KeyCode.O))
        {
            // 施加向上的力
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            /*
             // 不同的力的模式
rb.AddForce(Vector3.up * 5f, ForceMode.Force);      // 持续力（每帧施加）
rb.AddForce(Vector3.up * 5f, ForceMode.Acceleration); // 加速度
rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);    // 瞬间冲击力（最适合跳跃）
rb.AddForce(Vector3.up * 5f, ForceMode.VelocityChange); // 忽略质量的速度改变
             */
        }
    }
}