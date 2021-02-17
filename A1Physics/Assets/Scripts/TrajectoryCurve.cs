using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryCurve : MonoBehaviour
{
    private MouseFlickControl controlInst;

    Vector3 Direction;

    //public float force;

    public GameObject PointPrefab;

    public GameObject[] Points;

    public int numberOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        controlInst = GetComponent<MouseFlickControl>();
        
        Points = new GameObject[numberOfPoints];

        for(int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Direction = controlInst.move;


        for(int i = 0; i < Points.Length; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }
    }

    Vector3 PointPosition(float t)
    {
        Vector3 currentPointPos = transform.position + (Direction * 0.2f * t) + 0.5f * Physics.gravity * (t * t);
        return currentPointPos;
    }
}
