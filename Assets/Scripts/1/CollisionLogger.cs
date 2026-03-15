using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰到了：" + collision.gameObject.name);
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("离开了：" + collision.gameObject.name);
    }
}
