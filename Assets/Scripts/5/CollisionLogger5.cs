using UnityEngine;

public class CollisionLogger5 : MonoBehaviour
{
    // 当碰撞发生时调用（有物理碰撞）
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"【碰撞】碰到了：{collision.gameObject.name}");
    }

    // 当触发器触发时调用（没有物理碰撞）
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"【触发】进入了触发器：{other.gameObject.name}");
    }

    // 当触发器内持续停留时调用
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"【触发中】还在区域内：{other.gameObject.name}");
    }

    // 当离开触发器时调用
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"【离开】离开了触发器：{other.gameObject.name}");
    }
}
