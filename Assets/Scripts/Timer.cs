using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// see: https://www.youtube.com/watch?v=S12x7txHS1c
// Fixed timer using an timeSinceLevelLoad     see: https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoad.html
// Added a IEnumerator to allow a delay between changing to end scene 
public class Timer : MonoBehaviour
{
    bool startTimer = false;
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    public bool stopTimer;
    private IEnumerator coroutine;

    public GameObject timesUpText;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        stopTimer  = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        timesUpText.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer) {
            float time = gameTime - Time.timeSinceLevelLoad;

            int minutes = Mathf.FloorToInt(time/60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if(time <= 0) {
                coroutine = endOfGame(5.0F);
                StartCoroutine(coroutine);
                // stopTimer = true;
                // timesUpText.SetActive(true);
                // end game and reset score
                // SceneManager.LoadScene("EndScene");
                // ScoreKeeper.ResetScore();
            }

            if (stopTimer == false) {
                timerText.text = textTime;
                timerSlider.value = time;
            }
        }
    }

    private IEnumerator endOfGame(float waitTime)
    {
        stopTimer = true;
        timesUpText.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("EndScene");
        ScoreKeeper.ResetScore();
    }
}
