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

    public static Timer onGoingTime;

    bool startTimer = false;
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    public bool stopTimer;
    private IEnumerator coroutine;
    public float time;

    public GameObject timesUpText;

    private void Awake()
    {
        
        if (onGoingTime == null)
        {
            //Note: It was commented out because we do not need to keep for cheat sheet scene, it threw an error
            //DontDestroyOnLoad(this);
            //onGoingTime = this;
        }
        else
        {
            Destroy(gameObject);
        }
       if (timerSlider == null || timesUpText == null )
        {
            assign();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        stopTimer  = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        timesUpText.SetActive(false);
        
    }

    void FixedUpdate()
    {
        if (timerSlider == null)
        {
            assign();

        }
        if(gameTime <= 0)
        {
            coroutine = endOfGame(5.0F);
            StartCoroutine(coroutine);
            StopCoroutine(coroutine);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (startTimer) {
            time = gameTime - Time.timeSinceLevelLoad;

            int minutes = Mathf.FloorToInt(time/60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if(time <= 0) {
                coroutine = endOfGame(3.0F);
                StartCoroutine(coroutine);
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
        Destroy(gameObject);
    }

    void assign()
    {
        timerSlider = GameObject.FindGameObjectWithTag("TimesUpSlider").GetComponent<Slider>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        timesUpText = GameObject.FindGameObjectWithTag("TimesUpText");
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        timesUpText.SetActive(false);
    }
}
