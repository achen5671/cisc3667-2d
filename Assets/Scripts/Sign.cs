using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    static System.Random random = new System.Random();
    public bool isChest = false;
    public bool isSign = true;
    public Collider2D player; 
    // [SerializeField] AudioSource Source;
    [SerializeField] AudioClip wrong;
    [SerializeField] AudioClip correct;

    // Start is called before the first frame update
    void Awake()
    {
        if (isChest) {
            isSign = false;
            dialogBox = GameObject.Find("dialog box");
            dialogText = GameObject.FindGameObjectWithTag("DialogText").GetComponent<Text>();
            dialog = dialogText.text;

            // If it's a chest, randomly give dialog a verb from the list
            GetRandomConjugatedVerb();
        }
    }

    // The greeting dialog box needs to get off the screen this script will do that after 3 seconds
    IEnumerator Start()
    {
        dialogText.text = "Welcome to our game!! " + PersistentData.Instance.GetName() + " Have Fun!!";
        yield return new WaitForSeconds(3f);
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {
            if(dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
            }else {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.Q)) {
            InteractSign(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            playerInRange = true;
            player = other;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")){
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    public string GetDialogText() {
        if (!playerInRange) return "";
        return dialog;
    }

    // ### CONJUGATION CHECK
    // This should return a list 
    public List<string> GetConjugationValues(string pronoun) {
        string values = PlayerPrefs.GetString(pronoun);

        List<string> tokens = values.Split(", ").ToList();
        return tokens;
    }

    // todo: Get pronoun from text in the sign when user press 'q'
    // word is the conjugated verb in the chest
    public bool CheckConjugation(string pronoun, string word) {
        List<string> conjugations = GetConjugationValues(pronoun);
        return conjugations.Contains(word);
    }

    public void GetRandomConjugatedVerb() {
        string[] pronouns = {"yo", "tu", "el/ella/usted", "nosotros", "ellos/ellas/ustedes"};

        int value = random.Next(pronouns.Length);
        string pronoun = pronouns[value];

        List<string> conjugations = GetConjugationValues(pronoun);
        int rand = random.Next(conjugations.Count);

        // Debug.Log(conjugations[rand]);
        dialog = conjugations[rand];
    }

    // todo: need better name. If player press Q, call this function to check if conjugation is correct
    public void InteractSign(Collider2D player){
        PickUp verbSign = player.GetComponent<PickUp>();

        if (verbSign == null && !isSign) return;
        if (verbSign.itemHolding == null) return;

        if(CheckConjugation(dialog, verbSign.GetItemHoldingDialog())){
            // add score
            ScoreKeeper.AddScore();
            GetComponent<AudioSource>().PlayOneShot(correct);
            Destroy(verbSign.itemHolding);
        }else{
            ScoreKeeper.MinusScore();
            GetComponent<AudioSource>().PlayOneShot(wrong);
            Destroy(verbSign.itemHolding);
        }
    }

}
