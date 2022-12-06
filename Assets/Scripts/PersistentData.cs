using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    [SerializeField] int playerScore;
    [SerializeField] string playerName;

    // todo: create SoundManager.cs
    [SerializeField] float gameVolume;


    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // player will start out with 100 points and will lose points throughout the game
    
        playerScore = 100;
        playerName = "";
        gameVolume = 0.0F;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public void SetVolume(float vol)
    {
        gameVolume = vol;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public float GetVolume()
    {
        return gameVolume;

    }
}
