using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    float currentTime = 0f;
    float startingTime = 15f;

    public Text countdownText;
    public Text ScoreText;
    public Text restartText;
    public Text hardText;
    public Text gameOverText;
    public Text winText;
    public bool hardMode;

    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;

    private bool restart;
    private bool gameOver;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        winText.text = "";
        currentTime = startingTime;      
        hardText.text = "Press 'X' to SPEED THINGS UP";
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("Space Shooter");
            }           
        }

        if (Input.GetKeyDown(KeyCode.X))
        {            
            {
                hardMode = true;
            }
        }

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            gameOver = true;
            gameOverText.text = "Game Over!";
            restart = true;

            currentTime = 0;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You win! Game created by Tiana George";
            gameOverText.text = "";
            musicSource.clip = musicClipOne;
            musicSource.Play();
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        musicSource.clip = musicClipTwo;
        musicSource.Play();
        gameOverText.text = "Game Over!";
        winText.text = "";
        gameOver = true;
    }

}