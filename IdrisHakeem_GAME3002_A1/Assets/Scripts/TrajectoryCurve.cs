using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryCurve : MonoBehaviour
{
    private MouseFlickControl controlInst;

    Vector3 Direction;

    //public float force;

    public GameObject PointPrefab;

    private GameObject[] Points;

    public int numberOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        // gets instance of MouseFlickControl to get the initial trajectory vector
        controlInst = GetComponent<MouseFlickControl>();
        
        Points = new GameObject[numberOfPoints];

        // the Points array is populated with the prefab that represents points of the trajectory
        // based on the number of points you want the trajectory to have
        for(int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // the initial direction of the trajectory is taken from the controller for calculations
        Direction = controlInst.move;

        // The pointPrefab is used to plot the trajectory points and recreate the path the ball will take
        for(int i = 0; i < Points.Length; i++)
        {
            // the pointPrefab is placed in every interval of time using the Point position function
            Points[i].transform.position = PointPosition(i * 0.1f);
        }
    }

    // the PointPosition() takes an instance of time and finds the position the ball would be at that time
    Vector3 PointPosition(float t)
    {
        // This is a kinematic equation
        // finalPosition = InitialPosition + (Velocity * time) + (acceleration * time^2) / 2
        Vector3 currentPointPos = transform.position + (Direction * 0.2f * t) + 0.5f * Physics.gravity * (t * t);
        return currentPointPos;
    }
}
