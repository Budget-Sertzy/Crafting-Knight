using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainMenuSettingsUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;

    [Header("Settings UI")]
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;
    public Button applyButton;
    public Button backButton;

    [Header("Optional override (drag your GameSettings.asset here)")]
    public GameSettings Settings; // <-- assign in Inspector to avoid timing issues

    private Resolution[] _allResolutions;
    private List<Vector2Int> _uniqueResolutions;
    private bool _isInitializing;

    //private GameSettings Settings =>
       // overrideSettings != null
       //     ? overrideSettings
           // : (SceneController.Instance != null ? SceneController.Instance.gameSettings : null);

    private IEnumerator Start()
    {
        // Wait briefly for SceneController (if you're not using overrideSettings)
       // float t = 0f;
       // while (Settings == null && t < 2f) { t += Time.unscaledDeltaTime; yield return null; }

        if (Settings == null)
        {
            Debug.LogError("MainMenuSettingsUI: Could not find GameSettings. Either drag one into 'overrideSettings' or ensure SceneController exists and has one assigned.");
            yield break;
        }

        BuildResolutionOptions();
        SyncUIFromSettings();

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggled);
        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        applyButton.onClick.AddListener(OnApplyClicked);
        backButton.onClick.AddListener(OnBackClicked);
    }
    void OnDestroy()
    {
        // Clean up listeners (good hygiene)
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        fullscreenToggle.onValueChanged.RemoveListener(OnFullscreenToggled);
        resolutionDropdown.onValueChanged.RemoveListener(OnResolutionChanged);

        applyButton.onClick.RemoveListener(OnApplyClicked);
        backButton.onClick.RemoveListener(OnBackClicked);
    }

    // Called by your Settings button in the MainPanel
    public void OpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        // refresh in case anything changed externally
        SyncUIFromSettings();
    }

    private void OnBackClicked()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    private void OnApplyClicked()
    {
        if (Settings == null) return;
        Settings.SaveSettings(); // persist to PlayerPrefs
        Debug.Log("Settings saved.");
    }

    // ---- UI <-> Settings ----

    private void SyncUIFromSettings()
    {
        if (Settings == null) return;

        _isInitializing = true;

        // Volume
        volumeSlider.value = Mathf.Clamp01(Settings.masterVolume);

        // Fullscreen
        fullscreenToggle.isOn = Settings.fullscreen;

        // Resolution: find index that matches Settings
        int idx = IndexOfResolution(new Vector2Int(Settings.resolutionWidth, Settings.resolutionHeight));
        if (idx < 0)
        {
            // fallback to current screen resolution if Settings resolution isn't in the list
            idx = IndexOfResolution(new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height));
            if (idx < 0) idx = 0;
        }
        resolutionDropdown.value = idx;
        resolutionDropdown.RefreshShownValue();

        _isInitializing = false;
    }
public void ShowSettingsPanel()
{
    mainPanel.SetActive(false);
    settingsPanel.SetActive(true);

    // 🔄 Always reload latest saved settings from PlayerPrefs
    if (Settings != null)
    {
        Settings.LoadSettings();   // read last saved values
        Settings.ApplySettings();  // apply to game state (optional)
        SyncUIFromSettings();      // update sliders/toggles/dropdowns
    }
    else
    {
        Debug.LogWarning("MainMenuSettingsUI: No GameSettings available when opening Settings panel.");
    }
}
   private void BuildResolutionOptions()
{
    _allResolutions = Screen.resolutions;
    _uniqueResolutions = _allResolutions
        .Select(r => new Vector2Int(r.width, r.height))
        .Distinct()
        .OrderBy(v => v.x)
        .ThenBy(v => v.y)
        .ToList();

    var options = new List<TMP_Dropdown.OptionData>();
    foreach (var r in _uniqueResolutions)
    {
        options.Add(new TMP_Dropdown.OptionData($"{r.x} x {r.y}"));
    }

    resolutionDropdown.ClearOptions();
    resolutionDropdown.AddOptions(options);
}

    private int IndexOfResolution(Vector2Int wh)
    {
        for (int i = 0; i < _uniqueResolutions.Count; i++)
        {
            if (_uniqueResolutions[i].x == wh.x && _uniqueResolutions[i].y == wh.y)
                return i;
        }
        return -1;
    }

    // ---- Listeners ----

    private void OnVolumeChanged(float value)
    {
        if (Settings == null || _isInitializing) return;
        Settings.masterVolume = Mathf.Clamp01(value);
        Settings.ApplySettings(); // live preview
    }

    private void OnFullscreenToggled(bool isOn)
    {
        if (Settings == null || _isInitializing) return;
        Settings.fullscreen = isOn;
        // Keep current width/height from dropdown selection
        var sel = _uniqueResolutions[Mathf.Clamp(resolutionDropdown.value, 0, _uniqueResolutions.Count - 1)];
        Screen.SetResolution(sel.x, sel.y, isOn);
        Settings.ApplySettings();
    }

    private void OnResolutionChanged(int index)
    {
        if (Settings == null || _isInitializing) return;
        index = Mathf.Clamp(index, 0, _uniqueResolutions.Count - 1);
        var sel = _uniqueResolutions[index];

        Settings.resolutionWidth = sel.x;
        Settings.resolutionHeight = sel.y;

        // Apply with current fullscreen selection
        Screen.SetResolution(sel.x, sel.y, Settings.fullscreen);
        Settings.ApplySettings();
    }
    
}