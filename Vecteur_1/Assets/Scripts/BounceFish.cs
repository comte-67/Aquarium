using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFish : FishMouvement
{
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(3, 7);
        acceleration = Random.Range(1, 10);
        mouvement = new Vector3(Random.Range(-0.9f, 1), Random.Range(-0.9f, 1), Random.Range(-0.9f, 1));
    }

    // Update is called once per frame
    void Update()
    {
        DestinationToChange();

        MoveFish();

        DepasseLimite();
    }

    private new void DepasseLimite()
    {
        if ((transform.position.x + GetComponent<Renderer>().bounds.size.x / 2) > (aquarium.transform.position.x + aquarium.GetComponent<Renderer>().bounds.size.x / 2))
        {
            transform.position = new Vector3((aquarium.transform.position.x + aquarium.GetComponent<Renderer>().bounds.size.x / 2 - GetComponent<Renderer>().bounds.size.x / 2), transform.position.y, transform.position.z);
            mouvement = Vector3.Reflect(mouvement.normalized, Vector3.left);
        }

        if ((transform.position.x - GetComponent<Renderer>().bounds.size.x / 2) < (aquarium.transform.position.x - aquarium.GetComponent<Renderer>().bounds.size.x / 2))
        {
            transform.position = new Vector3((aquarium.transform.position.x - aquarium.GetComponent<Renderer>().bounds.size.x / 2 + GetComponent<Renderer>().bounds.size.x / 2), transform.position.y, transform.position.z);
            mouvement = Vector3.Reflect(mouvement.normalized, Vector3.right);
        }

        if ((transform.position.y + GetComponent<Renderer>().bounds.size.y / 2) > (aquarium.transform.position.y + aquarium.GetComponent<Renderer>().bounds.size.y / 2))
        {
            transform.position = new Vector3(transform.position.x, (aquarium.transform.position.y + aquarium.GetComponent<Renderer>().bounds.size.y / 2 - GetComponent<Renderer>().bounds.size.y / 2), transform.position.z);
            mouvement = Vector3.Reflect(mouvement.normalized, Vector3.up);
        }

        if ((transform.position.y - GetComponent<Renderer>().bounds.size.y / 2) < (aquarium.transform.position.y - aquarium.GetComponent<Renderer>().bounds.size.y / 2))
        {
            transform.position = new Vector3(transform.position.x, (aquarium.transform.position.y - aquarium.GetComponent<Renderer>().bounds.size.y / 2 + GetComponent<Renderer>().bounds.size.y / 2), transform.position.z);
            mouvement = Vector3.Reflect(mouvement.normalized, Vector3.down);
        }

        if ((transform.position.z + transform.GetComponent<Renderer>().bounds.size.z / 2) > (aquarium.transform.position.z + aquarium.GetComponent<Renderer>().bounds.size.z / 2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (aquarium.transform.position.z + aquarium.GetComponent<Renderer>().bounds.size.z / 2 - GetComponent<Renderer>().bounds.size.z / 2));
            mouvement = Vector3.Reflect(mouvement.normalized, Vector3.forward);
        }

        if ((transform.position.z - GetComponent<Renderer>().bounds.size.z / 2) < (aquarium.transform.position.z - aquarium.GetComponent<Renderer>().bounds.size.z / 2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (aquarium.transform.position.z - aquarium.GetComponent<Renderer>().bounds.size.z / 2 + GetComponent<Renderer>().bounds.size.z / 2));
            mouvement = Vector3.Reflect(mouvement.normalized, Vector3.back);
        }
    }
}
