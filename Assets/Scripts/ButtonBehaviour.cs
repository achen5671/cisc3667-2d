using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
     [SerializeField] InputField playerNameInput;
     [SerializeField] string s;
     [SerializeField] GameObject Warning;
     private IEnumerator coroutine;
     
    // Start is called before the first frame update
    void Start()
    {
        s = PersistentData.Instance.GetName();

        if (s != null)
        {
            playerNameInput.text = s;
        }
        
        Warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void MainMenu()
    {
        s = playerNameInput.text;
        //PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
        if(playerNameInput.text == "") {
            coroutine = showWarning(2.0F);
            StartCoroutine(coroutine);
            //Prevents Player from Starting the game without a name.
            Debug.Log("Player Name has not been input. Please put in a name.");
        }

        else {
            // This is to set the name in the PersistentData so that it follows along throughout the game
            s = playerNameInput.text;
            PersistentData.Instance.SetName(s);

            SceneManager.LoadScene("Start");
        }
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

    public void CheatSheet() {
        Timer.onGoingTime.gameTime = Timer.onGoingTime.time;
        SceneManager.LoadScene("Cheat sheet");
    }

    public void BackToPlay() {
        Timer.onGoingTime.gameTime = Timer.onGoingTime.time;
        SceneManager.LoadScene("Start");
    }
    

    private IEnumerator showWarning(float waitTime)
    {
        Warning.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Warning.SetActive(false);
    }
}
