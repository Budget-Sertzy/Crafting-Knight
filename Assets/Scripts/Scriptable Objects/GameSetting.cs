using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Audio")]
    [Range(0f, 1f)] public float masterVolume = 1f;

    [Header("Display")]
    public int resolutionWidth = 1920;
    public int resolutionHeight = 1080;
    public bool fullscreen = true;
    public bool vSync = true;

    [Header("Gameplay")]
    public float cameraSensitivity = 1f;

    // 🧩 Apply all settings immediately
    public void ApplySettings()
    {
        AudioListener.volume = masterVolume;
        Screen.SetResolution(resolutionWidth, resolutionHeight, fullscreen);
        QualitySettings.vSyncCount = vSync ? 1 : 0;
    }

    // 💾 Save to PlayerPrefs
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetInt("width", resolutionWidth);
        PlayerPrefs.SetInt("height", resolutionHeight);
        PlayerPrefs.SetInt("fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.SetInt("vSync", vSync ? 1 : 0);
        PlayerPrefs.SetFloat("cameraSensitivity", cameraSensitivity);
        PlayerPrefs.Save();
    }

    // 📥 Load from PlayerPrefs
    public void LoadSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("masterVolume", 1f);
        resolutionWidth = PlayerPrefs.GetInt("width", 1920);
        resolutionHeight = PlayerPrefs.GetInt("height", 1080);
        fullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        vSync = PlayerPrefs.GetInt("vSync", 1) == 1;
        cameraSensitivity = PlayerPrefs.GetFloat("cameraSensitivity", 1f);
    }
}