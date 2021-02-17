using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFlickControl : MonoBehaviour
{
    private GameObject block;

    private Rigidbody rb;

    private Vector3 init;
    private Vector3 final;
    private Vector3 diff;
    [HideInInspector]
    public Vector3 move;

    private Vector3 InitPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InitPos = transform.position;
        move = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        mouseKick();
        ResetBall();
    }

    void mouseKick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            init = Input.mousePosition;
            final = Input.mousePosition;

            diff = final - init;

            move.z = diff.y;
            move.x = diff.x / 4.0f;
            move.y = diff.y / 4.0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            final = Input.mousePosition;
            diff = (final - init) / 2.0f;


            if (diff.y > 0.0 * Screen.height)
            {
                move.z = diff.y;
                move.x = diff.x / 4.0f;
                move.y = diff.y / 4.0f;

                // move = Vector3.Normalize(move);

                rb.AddForce(0.2f * move, ForceMode.Impulse);
            }
        }
    }

    void ResetBall()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = InitPos;
            rb.velocity = Vector3.zero;
        }
    }
}
