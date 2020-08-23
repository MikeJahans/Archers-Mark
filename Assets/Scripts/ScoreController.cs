using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    public TextMeshProUGUI scoreText, hiScoreText, gameOverScoreText;
    public int score, hiScore = 0;

    public GameObject enemy, enemyToActivate;


    private void Awake()
    {
        instance = this;


    enemyToActivate.SetActive(false); // deactivate enemy at start


        if(PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetInt("HiScore");
            hiScoreText.text = hiScore.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 25)
        {
            enemyToActivate.SetActive(true); // if player reaches score, actiavte second enemy
        }
    }

    public void AddScore()
    {
        score++;
        UpdateHiScore();
        enemy.GetComponent<EnemyController>().speed += 0.025f; // when the score increases, slightly speed up enemy
        enemyToActivate.GetComponent<EnemyController>().speed += 0.025f; // when the score increases, slightly speed up enemy
        scoreText.text = score.ToString();
        //gameOverScoreText.text = score.ToString();
    }

    public void UpdateHiScore()
    {
        if (score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = hiScore.ToString();
            PlayerPrefs.SetInt("HiScore", hiScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void DeleteHighScore()
    {
        PlayerPrefs.DeleteKey("HiScore");
        hiScore = 0;
        hiScoreText.text = hiScore.ToString();
    }
}
