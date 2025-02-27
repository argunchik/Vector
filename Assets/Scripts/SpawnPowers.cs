using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowers : MonoBehaviour
{
    public Motio motio;
    public GameObject powerPrefab;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        int numberPowers=GameObject.FindGameObjectsWithTag("PowerUp").Length;
        print(numberPowers);
        print(motio.hasPowerUp);
        if (numberPowers<1 && motio.hasPowerUp==false)
        {
            Instantiate(powerPrefab);
        }
    }
}
