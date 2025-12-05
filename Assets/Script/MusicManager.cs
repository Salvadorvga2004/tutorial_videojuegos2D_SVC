using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("volume");
            audioSource.volume = savedVolume;
        }
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("volume", value);
        PlayerPrefs.Save();
    }

    public float CurrentVolume => audioSource.volume;
}
