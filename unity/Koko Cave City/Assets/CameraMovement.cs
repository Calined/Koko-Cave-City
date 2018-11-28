using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    void pushRay(Vector3 directionAndLength)
    {
        directionAndLength *= 0.4f;

        RaycastHit hitInfo;
        bool gotHit = Physics.Raycast(transform.position, directionAndLength, out hitInfo, Vector3.Distance(Vector3.zero, directionAndLength));

        if (gotHit)
        {

            Debug.DrawRay(transform.position, hitInfo.point - transform.position, Color.red);

            GetComponent<Rigidbody>().AddForce(-(directionAndLength - (hitInfo.point - transform.position)) * 5f * Time.deltaTime);

            Debug.Log(hitInfo.collider.name);

        }
        else
        {
            Debug.DrawRay(transform.position, directionAndLength, Color.white);
        }
    }

    void randomPushRayCasts(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            pushRay(Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //draw rays in all directions
        randomPushRayCasts(5);



    }



    private void FixedUpdate()
    {
        //anti gravity
        GetComponent<Rigidbody>().AddForce(Vector3.up * 49.5f * Time.deltaTime);

        //if mouse or finger holds
        if (Input.GetMouseButton(0))
        {

            //move forward
            GetComponent<Rigidbody>().AddForce(transform.forward * 3f * Time.deltaTime);

            //see if there is also sidewards movement
            GetComponent<Rigidbody>().AddTorque(Input.GetAxis("Mouse X") * transform.up * 20f);

            //see if there is also upwards/downwards movement
            GetComponent<Rigidbody>().AddTorque(Input.GetAxis("Mouse Y") * -transform.right * 20f);
        }
        else
        {
            //reduce rotation energy
            GetComponent<Rigidbody>().AddTorque(-GetComponent<Rigidbody>().angularVelocity * 0.5f);

        }


    }
}
