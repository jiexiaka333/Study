using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip footstepClip;   // 脚步声

    public void PlayFootstep()
    {
        // 播放一次脚步声（不循环）
        bgmSource.PlayOneShot(footstepClip);
    }
}
