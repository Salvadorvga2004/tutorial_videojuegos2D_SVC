using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (MusicManager.Instance != null)
        {
            slider.value = MusicManager.Instance.CurrentVolume;
        }

        // Activar actualización en tiempo real
        slider.onValueChanged.AddListener(OnSliderChange);
    }

    private void OnSliderChange(float value)
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.SetVolume(value);
        }
    }
}
