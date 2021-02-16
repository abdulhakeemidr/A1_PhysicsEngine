using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFlickControl : MonoBehaviour
{
    private GameObject block;

    private Rigidbody rb;

    private Vector3 init;
    private Vector3 final;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseKick();
    }

    void mouseKick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            init = Input.mousePosition;
            final = Input.mousePosition;

            //Debug.Log("a");
        }

        if (Input.GetMouseButtonUp(0))
        {
            final = Input.mousePosition;

            if (init.x > final.x)
            {
                Debug.Log("Left");
            }
            else if(init.x < final.x)
            {
                Debug.Log("Right");
            }


            Vector3 diff = final - init;
            Vector3 move;
            move.z = diff.y;
            move.x = diff.x;
            move.y = diff.z;

            move = Vector3.Normalize(move);

            rb.AddForce(move * 10.0f, ForceMode.Impulse);
        }
    }
}
