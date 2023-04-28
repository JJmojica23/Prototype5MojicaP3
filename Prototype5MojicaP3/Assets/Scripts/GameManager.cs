using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pausedScreen;
    private int lives;
    public bool isGamePaused = false;
    

    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        lives = 3;
        UpdateScore(0);
        UpdateLives(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == true)
        {
            pauseGame();
        }
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesLeft)
    {
        lives -= livesLeft;
        livesText.text = "Lives: " + lives;
    }

    public void GameOver()
    {
        if (lives <= 0)
        {
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            UpdateLives(+1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                pausedScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            else
            {
                pausedScreen.gameObject.SetActive(false);
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
        }
    }
}
