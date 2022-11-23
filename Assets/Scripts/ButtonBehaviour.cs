using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
     [SerializeField] InputField playerNameInput;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        // This is to set the name in the PersistentData so that it follows along throughout the game
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);

        SceneManager.LoadScene("Start");
    }

    public  void HowToPlay()
    {
        
        SceneManager.LoadScene("How To Play");
    }

    public  void Settings()
    {
        
        SceneManager.LoadScene("Settings");
    }

}
