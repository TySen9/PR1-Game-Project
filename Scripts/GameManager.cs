using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Makes an array to store gameobjects in called animal prefabs
    public List<GameObject> items;
    public List<GameObject> apple;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winnerText;
    public int health = 5;
    public int score;
    private float spawnInterval = 1.5f;
    private float appleSpawn = 2.5f;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update

    void Start()
    {
        //Repeats SpawnRandomSpawn starting from startDelay and every spawnInterval
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        Winner();
    }

    IEnumerator SpawnTarget()
    {
       while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, items.Count);
            Instantiate(items[index]);
        }
    }

    IEnumerator SpawnApple()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(appleSpawn);
            int appleindex = Random.Range(0, apple.Count);
            Instantiate(apple[appleindex]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int healthToAdd)
    {
        health += healthToAdd;
        healthText.text = "Health: " + health;
    }

    public void GameOver()
    {
        if (health == 0)
        {
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnApple());
        score = 0;
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        GameOver();
        Winner();
    }

    public void Winner()
    {
        if (score >= 69)
        {
            isGameActive = false;
            winnerText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            
        }
    }

    //Randomly generate spawn index and spawn position
}
