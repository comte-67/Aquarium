using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquariumManager : MonoBehaviour
{
    public LimitAquarium limitAquarium;
    public Vector3 cordo;
    public Material materiauxTransparent;
    public GameObject[] fish;
    public GameObject fishLeader;
    public int nbrFish;
    public int nbrFishLeader;
    public Material[] listeCouleur;

    public GameObject[] listLeaderFish;
    private GameObject[] listLeaderFishBackup;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = cordo;
        cube.transform.localScale = limitAquarium.limit;
        cube.GetComponent<BoxCollider>().isTrigger = true;
        cube.GetComponent<MeshRenderer>().material = materiauxTransparent;

        for(int i = 0; i<nbrFish; i++)
        {
            GameObject fishIntance = Instantiate(fish[Random.Range(0, fish.Length)], new Vector3(Random.Range(cordo.x - limitAquarium.limit.x / 2, cordo.x + limitAquarium.limit.x / 2), Random.Range(cordo.y - limitAquarium.limit.y / 2, cordo.y + limitAquarium.limit.y / 2), Random.Range(cordo.z - limitAquarium.limit.z / 2, cordo.z + limitAquarium.limit.z / 2)), Quaternion.identity);
            fishIntance.GetComponent<FishMouvement>().aquarium = cube;
            fishIntance.GetComponent<FishMouvement>().aquariumManager = this.gameObject;
            fishIntance.GetComponent<MeshRenderer>().material = listeCouleur[Random.Range(0, listeCouleur.Length)];
        }

        for (int i = 0; i < nbrFishLeader; i++)
        {
            GameObject fishIntance = Instantiate(fishLeader, new Vector3(Random.Range(cordo.x - limitAquarium.limit.x / 2, cordo.x + limitAquarium.limit.x / 2), Random.Range(cordo.y - limitAquarium.limit.y / 2, cordo.y + limitAquarium.limit.y / 2), Random.Range(cordo.z - limitAquarium.limit.z / 2, cordo.z + limitAquarium.limit.z / 2)), Quaternion.identity);
            fishIntance.GetComponent<FishMouvement>().aquarium = cube;
            fishIntance.GetComponent<FishMouvement>().aquariumManager = this.gameObject;
            fishIntance.GetComponent<MeshRenderer>().material = listeCouleur[Random.Range(0, listeCouleur.Length)];
            listLeaderFishBackup = new GameObject[i + 1];
            listLeaderFish.CopyTo(listLeaderFishBackup, 0);
            listLeaderFish = new GameObject[i];
            listLeaderFish = listLeaderFishBackup;
            listLeaderFish[i] = fishIntance;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        
    }
}
