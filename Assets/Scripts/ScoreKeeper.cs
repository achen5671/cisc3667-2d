using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] static int score;
    const int DEFAULT_POINTS = 25;
    [SerializeField] public Text scoreTxt;


    // Start is called before the first frame update
    void Start()
    {
        // this script will get the current sore from the Persistant data 
        // makes sense for the Persistant data script to keep track of the score and for this script to update the score

        score = PersistentData.Instance.GetScore();
        DisplayScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }

    public static int GetScore() {
        return score;
    }

    public static void AddPoints(int points)
    {
        score += points;

        PersistentData.Instance.SetScore(score);


    }


    public static void AddScore()
    {
        AddPoints(DEFAULT_POINTS);
    }
    
    public static void MinusScore()
    {
        AddPoints(-DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public static void ResetScore() {
        score = 0;
    }
}
