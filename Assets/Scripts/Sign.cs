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
    public bool isChest = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            playerInRange = true;

            PickUp verbSign = other.GetComponent<PickUp>();
            if (verbSign != null) {
                if(CheckConjugation(dialog, verbSign.GetItemHoldingDialog())){
                    // add score
                    ScoreKeeper.AddScore();
                    // todo: play sound
                    Debug.Log("SCORE!");
                    // Destroy(verbSign.GetItem());
                }else{
                    ScoreKeeper.MinusScore();
                    // todo: play sound
                    Debug.Log("WRONG!");

                }
            } 
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

}
