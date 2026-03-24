using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;      // 前后移动速度
    public float rotateSpeed = 100f;  // 旋转速度（度/秒）

    private Animator _animator;

    public AudioSource bgmSource;
    public AudioClip footstepClip;   // 脚步声

    public ParticleSystem flameEffect;
    public ParticleSystem explosionPrefab;

   
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
            Vector3 move =  new Vector3(1,0,0)* v * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.Self);
        }
        // 按 F 键开关火焰
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flameEffect.isPlaying)
                flameEffect.Stop();
            else
                flameEffect.Play();
        }

        // 按 E 键播放爆炸
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticleSystem exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            exp.Play();
            Destroy(exp.gameObject, exp.main.duration);
        }
        // ===== 3. 动画参数 =====
        // 用 v 的绝对值表示移动速度（只关心前后，不管方向）

        /*Mathf.Abs(v) 取绝对值，把负值变成正值

例如：v = -0.5 → moveSpeedForAnim = 0.5

为什么取绝对值？因为动画通常不分前后，无论是向前走还是向后走，用的都是同一套走路动画（只是角色面朝方向不同）*/
        float moveSpeedForAnim = Mathf.Abs(v);
        _animator.SetFloat("Speed", moveSpeedForAnim);
    }

    // 动画事件调用的方法
    public void Footstep()
    {
        bgmSource.PlayOneShot(footstepClip);
        Debug.Log("播放");
    }
}
