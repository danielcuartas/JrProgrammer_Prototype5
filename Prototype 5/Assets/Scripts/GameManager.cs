using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    

    float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;

    void Start()
    {
        
    }

    IEnumerator spawnObjects()
    {
        while(isGameActive)
        {
            
            int index = Random.Range(0, targets.Count);
            Debug.Log(index);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targets[index]);
            
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(float diff)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= diff;
        StartCoroutine(spawnObjects());
        scoreText.text = "Score: " + score;
        titleScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
