// GameSettings.cs（你已有的脚本）
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource bgmAudioSource;

    void Start()
    {
        // 加载保存的音量设置
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);

        if (volumeSlider != null)
            volumeSlider.value = savedVolume;

        if (bgmAudioSource != null)
            bgmAudioSource.volume = savedVolume;

        // 监听滑动条变化
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        // 实时调整音量
        if (bgmAudioSource != null)
            bgmAudioSource.volume = volume;

        // 保存设置
        PlayerPrefs.SetFloat("GameVolume", volume);
        PlayerPrefs.Save();
    }
}
