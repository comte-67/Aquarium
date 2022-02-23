using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMouvement : MonoBehaviour
{
    public GameObject aquarium;
    public GameObject aquariumManager;

    protected float timeMove;
    protected float speed;
    protected float acceleration;
    protected Vector3 mouvement;
    protected float timeMoveCounter = 0;
    protected bool changeDestination = true;
    
    // Start is called before the first frame update
    /*void Start()
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
    }*/

    protected void ResetTimeMove()
    {
        timeMoveCounter = 0;
        changeDestination = true;
        timeMove = Random.Range(2, 10);
    }

    protected void TimeToMove()
    {
        timeMoveCounter += Time.deltaTime;

        if (timeMoveCounter >= timeMove)
        {
            ResetTimeMove();
        }
    }

    protected void DestinationToChange()
    {
        if (changeDestination == true)
        {
            mouvement = new Vector3(Random.Range(-0.9f, 1), Random.Range(-0.9f, 1), Random.Range(-0.9f, 1));
            changeDestination = false;
        }
    }

    protected void MoveFish()
    {
        mouvement = mouvement.normalized * (speed + acceleration * Time.deltaTime) * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mouvement), 1);
        transform.position = transform.position + mouvement;
    }

    protected void DepasseLimite()
    {
        if ((transform.position.x + GetComponent<Renderer>().bounds.size.x / 2) > (aquarium.transform.position.x + aquarium.GetComponent<Renderer>().bounds.size.x / 2))
        {
            transform.position = new Vector3((aquarium.transform.position.x + aquarium.GetComponent<Renderer>().bounds.size.x / 2 - GetComponent<Renderer>().bounds.size.x / 2), transform.position.y, transform.position.z);
            ResetTimeMove();
        }

        if ((transform.position.x - GetComponent<Renderer>().bounds.size.x / 2) < (aquarium.transform.position.x - aquarium.GetComponent<Renderer>().bounds.size.x / 2))
        {
            transform.position = new Vector3((aquarium.transform.position.x - aquarium.GetComponent<Renderer>().bounds.size.x / 2 + GetComponent<Renderer>().bounds.size.x / 2), transform.position.y, transform.position.z);
            ResetTimeMove();
        }

        if ((transform.position.y + GetComponent<Renderer>().bounds.size.y / 2) > (aquarium.transform.position.y + aquarium.GetComponent<Renderer>().bounds.size.y / 2))
        {
            transform.position = new Vector3(transform.position.x, (aquarium.transform.position.y + aquarium.GetComponent<Renderer>().bounds.size.y / 2 - GetComponent<Renderer>().bounds.size.y / 2), transform.position.z);
            ResetTimeMove();
        }

        if ((transform.position.y - GetComponent<Renderer>().bounds.size.y / 2) < (aquarium.transform.position.y - aquarium.GetComponent<Renderer>().bounds.size.y / 2))
        {
            transform.position = new Vector3(transform.position.x, (aquarium.transform.position.y - aquarium.GetComponent<Renderer>().bounds.size.y / 2 + GetComponent<Renderer>().bounds.size.y / 2), transform.position.z);
            ResetTimeMove();
        }

        if ((transform.position.z + transform.GetComponent<Renderer>().bounds.size.z / 2) > (aquarium.transform.position.z + aquarium.GetComponent<Renderer>().bounds.size.z / 2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (aquarium.transform.position.z + aquarium.GetComponent<Renderer>().bounds.size.z / 2 - GetComponent<Renderer>().bounds.size.z / 2));
            ResetTimeMove();
        }

        if ((transform.position.z - GetComponent<Renderer>().bounds.size.z / 2) < (aquarium.transform.position.z - aquarium.GetComponent<Renderer>().bounds.size.z / 2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (aquarium.transform.position.z - aquarium.GetComponent<Renderer>().bounds.size.z / 2 + GetComponent<Renderer>().bounds.size.z / 2));
            ResetTimeMove();
        }
    }
}
