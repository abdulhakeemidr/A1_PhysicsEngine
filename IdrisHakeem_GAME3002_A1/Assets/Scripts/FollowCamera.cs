using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 temp;


    private void Start()
    {
        temp.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        temp = Input.mousePosition;
        //temp.z = 15f;
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}
