using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 100f;

    private Animator _animator;

    [Header("音效")]
    public AudioSource footstepSource;
    public AudioClip footstepClip;

    [Header("特效")]
    public ParticleSystem flameEffect;
    public ParticleSystem explosionPrefab;

    private bool isFlag = true;

    void Start()
    {
        _animator = GetComponent<Animator>();

        // 设置脚步声为 3D 音效
        if (footstepSource != null)
            footstepSource.spatialBlend = 1f;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 旋转
        if (h != 0)
        {
            transform.Rotate(Vector3.up, h * rotateSpeed * Time.deltaTime);
        }

        // 移动
        if (v != 0)
        {
            Vector3 move = new Vector3(1,0,0) * v * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.Self);
        }

        // 火焰特效开关
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlame();
        }

        // 爆炸特效
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnExplosion();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(isFlag==false)
            {
                Debug.Log("还在冷却");
            }
            else
            {
                StartCoroutine(Fs());
               
            }
            
             
        }
        // 动画参数
        float moveSpeedForAnim = Mathf.Abs(v);
        _animator.SetFloat("Speed", moveSpeedForAnim);
    }
    IEnumerator Fs()
    {
        Debug.Log("显示发射进入冷却");
        isFlag = false;
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("冷却结束");
        isFlag = true;
    }

    // 动画事件调用的方法
    public void Footstep()
    {
        if (footstepSource != null && footstepClip != null)
        {
            footstepSource.PlayOneShot(footstepClip);
            Debug.Log("脚步声播放");
        }
    }

    // 火焰特效控制
    public void ToggleFlame()
    {
        if (flameEffect == null) return;

        if (flameEffect.isPlaying)
            flameEffect.Stop();
        else
            flameEffect.Play();
    }

    public bool IsFlameActive()
    {
        return flameEffect != null && flameEffect.isPlaying;
    }

    public void SetFlameActive(bool active)
    {
        if (flameEffect == null) return;

        if (active && !flameEffect.isPlaying)
            flameEffect.Play();
        else if (!active && flameEffect.isPlaying)
            flameEffect.Stop();
    }

    // 爆炸特效
    public void SpawnExplosion()
    {
        if (explosionPrefab == null) return;

        ParticleSystem exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        exp.Play();
        Destroy(exp.gameObject, exp.main.duration);
    }
}
