using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuScoreController : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText, hiScoreText, gameOverScoreText;
    public int score, hiScore = 0;
    

    void Awake(){
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
        
    }
}
