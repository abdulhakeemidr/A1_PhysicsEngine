using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 temp;


    //private void Start()
    //{
    //    temp.z = transform.position.z;
    //}

    // Update is called once per frame
    void Update()
    {
        // Gets the current mouse position
        temp = Input.mousePosition;
        //temp.z = 15f;

        // Ensures the drawManager is always following the mouse
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}
