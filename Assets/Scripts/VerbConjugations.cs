using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbConjugations : MonoBehaviour
{
    // unused for now
    public const int NUM_VERBS = 5;

    // Start is called before the first frame update
    void Start()
    {
        ConjugationList();
        Debug.Log("LOGGED");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConjugationList() {
        // values are separated by commas
        // Can value be a vector or an array?
        // Is there a better way to handle this?
        // todo: add more words and randomly spawn the word/box on the screen.
        // todo: need to add definitions / translate word to english
        // Easier way /hack. Created a another scene or overlap as a cheat sheet (I like this idea, simple and save time)
        var conjugations = new Dictionary<string, string>(){
            {"yo", "soy, he, estoy, tengo, hago"},
            {"tu", "eres, has, estas, tienes, haces"},
            {"el/ella/usted", "es, ha, esta, tiene, hace"},
            {"nosotros", "somos, hemos, estamos, tenemos, hacemos"},
            {"ellos/ellas/ustedes", "son, han, estan, tienen, hacen"}
        };

        foreach (var (key, value) in conjugations){
            PlayerPrefs.SetString(key, value);
        }
    }
}
