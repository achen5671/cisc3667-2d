using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "HSName";
    public const string SCORE_KEY = "HSScore";
    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
       playerName = PersistentData.Instance.GetName();
       playerScore = ScoreKeeper.GetScore();

       SaveScore();

    }

    public void SaveScore()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerScore = tempScore;
                    playerName = tempName;
                }
            }

            else
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }

    public void ViewHighScores()
    {

    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + i);
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
        }
        
    }


}
