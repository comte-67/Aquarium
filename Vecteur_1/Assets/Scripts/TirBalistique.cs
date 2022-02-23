using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirBalistique : MonoBehaviour
{

    private LineRenderer lineRenderer;
    [Range(1, 100)]
    public int densite = 0;
    [Range(0, 90)]
    public float angle = 0;
    public float force = 0;
    public float gravityCoeff = 1;
    public float distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        lineRenderer.positionCount = densite;
        
        lineRenderer.SetPosition(0, transform.position);

        for(int i = 1; i<densite; i++)
        {
            lineRenderer.SetPosition(i, lineRenderer.GetPosition(i-1)+ (new Vector3(1,1,0) *force + Physics.gravity*gravityCoeff*i)*distance);
        }
    }

}
