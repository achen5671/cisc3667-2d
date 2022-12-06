using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
     [SerializeField] InputField playerNameInput;
     [SerializeField] string s;
     
    // Start is called before the first frame update
    void Start()
    {
        s = PersistentData.Instance.GetName();

        if (s != null)
        {
            playerNameInput.text = s;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void MainMenu()
    {
        s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        // This is to set the name in the PersistentData so that it follows along throughout the game
        s = playerNameInput.text;
        PersistentData.Instance.SetName(s);

        SceneManager.LoadScene("Start");
    }

    public void HowToPlay()
    {
        s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("How To Play");
    }

    public void Settings()
    {
        s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Settings");
    }

    //unused for now
    public void EndGame() {
        SceneManager.LoadScene("EndScene");
    }

}
