using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MouvementDeObjet : MonoBehaviour
{
    protected Vector3 cordo;
    [SerializeField] protected Vector3 destination;
    private bool endLerp = false;
    

    protected IEnumerator GoToDestination(int coeffSpeed)
    {
        endLerp = false;
        //transform.position = Vector3.Lerp(cordo, new Vector3(10, 10, 10), 0);
        for(int i = 1; i<coeffSpeed; i++)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector3.Lerp(cordo, destination, (float)i / (float)coeffSpeed);
            if (endLerp == true)
            {
                break;
            }
            //transform.position = new Vector3(Mathf.Lerp(cordo.x, 10, (float)i / 1000), Mathf.Lerp(cordo.y, 10, (float)i / 1000), 0);
        }
    }

    protected IEnumerator circularLerp()
    {
        endLerp = false;
        while (true)
        {
            for (int i = 1; i < 1000; i++)
            {
                yield return new WaitForEndOfFrame();
                transform.position = new Vector3(cordo.x + destination.x * Mathf.Cos(Mathf.Lerp(0, 2*Mathf.PI, (float)i / 1000)), cordo.y + destination.y * Mathf.Sin(Mathf.Lerp(0, 2*Mathf.PI, (float)i / 1000)), cordo.z + destination.z * Mathf.Cos(Mathf.Lerp(0, 2*Mathf.PI, (float)i / 1000)));
                if (endLerp == true)
                {
                    yield break;
                }
            }

        }
        
    }
}

public class MouvementLerp : MouvementDeObjet
{
    // Start is called before the first frame update
    void Start()
    {
        cordo = transform.position;
        StartCoroutine(GoToDestination(10000));
        StartCoroutine(circularLerp());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(cordo, new Vector3(10, 10, 10), 0.5f);
    }
}
