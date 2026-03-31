using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //ΩÃ±€≈Ê

    public int score = 0;
    public int life = 3;


    public TMP_Text scoreText;
    public TMP_Text lifeText;
    public GameObject gameOverPanel;

    bool isGameOver;

    private void Awake()
    {
        Instance = this; //ΩÃ±€≈Ê
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
       //LoseLife();
    }

    public void AddScore(int point)
    {
        score += point;
        UpdateUI(); 
    }

    public void LoseLife()
    {
        life--;
        UpdateUI(); 

        if (life <= 0)
        {
            GameOver();
        }
    }

    private void UpdateUI()
    {      
        scoreText.text = "Score: " + score;
        lifeText.text = "Life: " + life;  
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
