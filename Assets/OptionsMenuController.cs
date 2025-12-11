using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] Slider masterVolume;
    [SerializeField] Toggle fullscreen;
    [SerializeField] TMP_Dropdown quality;
    [SerializeField] MasterVolume masterVolumeController; // ini script pengatur mixer

    const string KEY_VOL = "opt_volume";

    void OnEnable()
    {
        float vol = PlayerPrefs.GetFloat(KEY_VOL, 0.8f);
        masterVolume.SetValueWithoutNotify(vol);
        masterVolumeController.SetVolume(vol); // sinkron mixer

        fullscreen.SetIsOnWithoutNotify(Screen.fullScreen);

        quality.ClearOptions();
        quality.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));
        quality.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
    }

    public void OnVolumeChanged(float v)
    {
        masterVolumeController.SetVolume(v); // panggil mixer
    }

    public void OnFullscreenChanged(bool on)
    {
        Screen.fullScreen = on;
    }

    public void OnQualityChanged(int idx)
    {
        QualitySettings.SetQualityLevel(idx, true);
    }

    public void OnApply()
    {
        PlayerPrefs.SetFloat(KEY_VOL, masterVolume.value);
        PlayerPrefs.Save();
    }
}
