using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidFish : FishMouvement
{
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 2);
        acceleration = Random.Range(1, 10);
        timeMove = Random.Range(2, 10);
    }

    // Update is called once per frame
    void Update()
    {
        DestinationToChange();

        MoveFish();

        DepasseLimite();

        TimeToMove();
    }
}
