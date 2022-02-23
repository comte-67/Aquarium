using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFish : FishMouvement
{
    public LeaderFish leaderFish;
    public float angleDetection;
    public float distanceDetection;

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
        if(leaderFish != null)
        {
            mouvement = (leaderFish.gameObject.transform.position - transform.position).normalized;
            MoveFish();
            OutRangeLeader();
        }
        else
        {
            DestinationToChange();

            MoveFish();

            DepasseLimite();

            TimeToMove();

            DetectLeader();

            //Vector3.Dot(transform.position, transform.position);
        }
        
    }

    void DetectLeader()
    {
        for(int i = 0; i < aquariumManager.GetComponent<AquariumManager>().listLeaderFish.Length; i++)
        {
            Vector3 toLeaderFish = aquariumManager.GetComponent<AquariumManager>().listLeaderFish[i].transform.position - transform.position;
            if (toLeaderFish.magnitude <= distanceDetection)
            {
                if(Vector3.Dot(toLeaderFish.normalized, transform.forward) > Mathf.Cos(angleDetection * 0.5f * Mathf.Deg2Rad))
                {
                    leaderFish = aquariumManager.GetComponent<AquariumManager>().listLeaderFish[i].GetComponent<LeaderFish>();
                    speed = Random.Range(0.5f, 2.5f);
                    break;
                }
            }
        }
    }

    void OutRangeLeader()
    {
        Vector3 toLeaderFish = leaderFish.gameObject.transform.position - transform.position;
        if ((toLeaderFish.magnitude > distanceDetection) || (Vector3.Dot(toLeaderFish.normalized, transform.forward) <= Mathf.Cos(angleDetection * 0.5f * Mathf.Deg2Rad)))
        {
            speed = Random.Range(0.5f, 2);
            leaderFish = null;
        }

        
    }
}
