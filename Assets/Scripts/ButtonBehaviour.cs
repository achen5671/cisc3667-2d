using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
     [SerializeField] InputField playerNameInput;
     [SerializeField] string s; // what is s?
     public GameObject BackToGameButton;
     public GameObject Warning;
     private IEnumerator coroutine;
     private Scene scene;
     public GameObject timesUpText;
     public GameObject timerSlider;
     public GameObject cheatSheet;
    
     
    // Start is called before the first frame update
    void Start()
    {
        s = PersistentData.Instance.GetName();

        if (s != null)
        {
            playerNameInput.text = s;
        }

        if (Warning) Warning.SetActive(false);
        if (BackToGameButton && s == null) BackToGameButton.SetActive(false);
        else if (BackToGameButton && s != null) BackToGameButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Cheat sheet" && Timer.onGoingTime == null)
        {
            if(timesUpText == null)
            {
                timesUpText = GameObject.FindGameObjectWithTag("TimesUpText");
                timesUpText.SetActive(false);
                timerSlider = GameObject.FindGameObjectWithTag("TimesUpSlider");
                timerSlider.SetActive(false);
            }
            

        }
    }

    
    public void MainMenu()
    {
        s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
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
            ScoreKeeper.ResetScore();
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

    // todo: all this can be static
    public void EndGame() {
        Timer.onGoingTime.gameTime = 0;
        SceneManager.LoadScene("EndScene");
    }

    public void CheatSheet() {
        Timer.onGoingTime.gameTime = Timer.onGoingTime.time;
        SceneManager.LoadScene("Cheat sheet");
    }

    public void CheatSheetPanel() {
        cheatSheet.SetActive(true);
    }

    public void BackToPlay() {
        if (s != null) {
            Timer.onGoingTime.gameTime = Timer.onGoingTime.time;
            SceneManager.LoadScene("Start");
        }
    }

    public void BackToPlayPanel() {
        if (s != null) {
            cheatSheet.SetActive(false);
        }
    }
    
    public void CheatSheetWithoutTime() {
        SceneManager.LoadScene("Cheat sheet");
    }

    private IEnumerator showWarning(float waitTime)
    {
        Warning.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Warning.SetActive(false);
    }
}
