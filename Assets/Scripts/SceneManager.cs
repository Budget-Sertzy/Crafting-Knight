using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [Header("Scene Management")]
    public string CurrentScene;

    [Header("References")]
    public GameSettings gameSettings; // assign your ScriptableObject here

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (gameSettings != null)
            {
                gameSettings.LoadSettings();
                gameSettings.ApplySettings();
            }
            else
            {
                Debug.LogWarning("SceneController: No GameSettings asset assigned!");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyAndSaveSettings()
    {
        if (gameSettings != null)
        {
            gameSettings.ApplySettings();
            gameSettings.SaveSettings();
        }
    }

    // Scene management
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(CurrentScene);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ExitGame()
    {
        if (Application.isPlaying && !Application.isEditor)
            Application.Quit();
        else
            Debug.Log("ExitGame called, but ignored in Editor.");
    }
}