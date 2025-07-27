using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;

    public Text scoreText;           // Assign your Score UI Text here
    public Text livesText;           // Assign your Lives UI Text here
    public GameObject gameOverPanel; // Assign your Game Over UI Panel here

    private bool isGameOver = false;

    void Start()
    {
        UpdateUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void IncreaseScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateUI();
    }

   /* public void DecreaseLives(int amount)
    {
        if (isGameOver) return;

        lives -= amount;
        if (lives < 0) lives = 0;
        UpdateUI();

        if (lives == 0)
        {
            HandleGameOver();
        }
    }*/

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    private void HandleGameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}


    public bool IsGameOver()
{
    return isGameOver;
}
public void DecreaseScore(int amount)
{
    if (isGameOver) return;

    score -= amount;
    Debug.Log($"Score decreased by {amount}. New score: {score}");

    UpdateUI();

    if (score < 0)
    {
        HandleGameOver();
    }
}

}
