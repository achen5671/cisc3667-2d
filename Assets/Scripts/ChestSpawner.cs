using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    const int Num_of_Chest = 5;
    [SerializeField] GameObject Chest;
    // Start is called before the first frame update
    void Start()
    {
        if(Chest == null){
            Chest = GameObject.FindGameObjectWithTag("Chest");
        }

        Spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float xMin = -1.5F;
        float xMax = 1.576F;
        float yMin = -0.795F;
        float yMax = 0.927F;

        for (int i = 0; i < Num_of_Chest; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(Chest, position, Quaternion.identity);
        }
    }
}
