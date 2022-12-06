using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbConjugations : MonoBehaviour
{
    // unused for now
    public const int NUM_VERBS = 5;

    // Start is called before the first frame update
    public void Awake()
    {
        ConjugationList();
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
            {"yo", "soy ,he, estoy, tengo, hago, puedo, digo, voy, veo, doy, se, quiero, llego, paso, debo, pongo, parezco, quedo, creo, hablo, llevo, dejo, sigo, encuentro, llamo, como"},
            {"tu", "eres, has, estas, tienes, haces, puedes, dices, vas, ves, das, sabes, quieres, llegas, pasas, debes, pones, paraces, quedas, crees, hablas, llevas, dejas, sigues, encuentras, llamas, comes"},
            {"el/ella/usted", "es, ha, esta, tiene, hace, puede, dice, va, ve, da, sabe, quiere, llega, pasa, debe, pone, parace, queda, cree, habla, lleva, deja, sigue, encuentra, llama, come"},
            {"nosotros", "somos, hemos, estamos, tenemos, hacemos, podemos, decimos, vamos, vemos, damos, sabemos, queremos, llegamos, pasamos, debemos, ponemos, paracemos, quedamos, creemos, hablamos, llevamos, dejamos, segimos, encontramos, llamamos, comemos"},
            {"ellos/ellas/ustedes", "son, han, estan, tienen, hacen, pueden, dicen, van, ven, dan, saben, quieren, llegan, pasan, deben, ponen, paracen, quedan, creen, hablan, llevan, dejan, siguen, encuentran, llaman, comen"}
        };

        foreach (var (key, value) in conjugations){
            PlayerPrefs.SetString(key, value);
        }
    }
}
