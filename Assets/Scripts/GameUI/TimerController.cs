using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class TimerController : MonoBehaviour
{
    public float startTime = 60f; // Initial time in seconds
    private float currentTime;
    public TextMeshProUGUI timerText; // Reference to your TextMeshPro text
    
    public GameObject Enemies;
    public GameObject boss;

    private bool hasSpawned = false;

    private bool timerActive = false;
    

    void Start()
    {
        currentTime = startTime;
        UpdateTimerDisplay();
        StartTimer();
        
    }

    void Update()
    {
        if (timerActive)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                currentTime = 0;
                timerActive = false;
                UpdateTimerDisplay();
                
            }
        }
        if (!timerActive)
        {
            timerText.text = ("Boss Time");
            Enemies.SetActive(false);

            if (!hasSpawned)
            {
                boss.SetActive(true);
                hasSpawned = true;
            }

        }

        
        
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

   
    public void StartTimer()
    {
        currentTime = startTime; 
        timerActive = true;
        
        timerText.gameObject.SetActive(true); 
        
    }
    
    

   
}