using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
   public static SceneController Instance;
    public string CurrentScene;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persist between scenes
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }
       // Call this to quit the game at runtime
    public void ExitGame()
    {
        // Only works in the built game
        if (Application.isPlaying && !Application.isEditor)
        {
            Application.Quit();
        }
        else
        {
            Debug.Log("ExitGame called, but ignored in Editor.");
        }
    }
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
}
