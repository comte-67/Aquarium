using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderFish : StupidFish
{
    void Start()
    {
        speed = Random.Range(3, 4);
        acceleration = Random.Range(1, 10);
        timeMove = Random.Range(2, 10);
    }
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
