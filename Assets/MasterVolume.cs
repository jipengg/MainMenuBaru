using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        float volume;
        if (mixer.GetFloat("MasterVolume", out volume))
            slider.value = Mathf.Pow(10, volume / 20);

        slider.minValue = 0.0001f; // biar ga error Log10
        slider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }
}
