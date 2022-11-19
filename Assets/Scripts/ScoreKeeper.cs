using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] static int score;
    const int DEFAULT_POINTS = 25;
    [SerializeField] Text scoreTxt;


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
        
    }

    public void AddPoints(int points)
    {
        score -= points;

        DisplayScore();

        PersistentData.Instance.SetScore(score);


    }


    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }



}
