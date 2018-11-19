using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if mouse of finger holds
        if (Input.GetMouseButton(0))
        {
            //move forward
            GetComponent<Rigidbody>().AddForce(transform.forward * 2 * Time.deltaTime);
        }
    }
}
