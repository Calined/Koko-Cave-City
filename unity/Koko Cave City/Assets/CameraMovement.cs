using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private float stayCount = 0.0f;
    private void OnCollisionStay(Collision collision)
    {
        //if time is up
        if (stayCount > 1f)
        {

            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.Log("drawing");
                Debug.DrawRay(contact.point, contact.normal, Color.white);

                //apply force away from the collision point
                GetComponent<Rigidbody>().AddForce(Vector3.Normalize(transform.position - contact.point) * 5f * Time.deltaTime / Vector3.Distance(transform.position, contact.point));

            }


            //reset
            stayCount -= 1f;
        }
        else
        {
            stayCount += Time.deltaTime;
        }

    }

    // Update is called once per frame
    void Update()
    {


    }



    private void FixedUpdate()
    {
        //anti gravity
        GetComponent<Rigidbody>().AddForce(Vector3.up * 49.5f * Time.deltaTime);



        //if mouse or finger holds
        if (Input.GetMouseButton(0))
        {

            //move forward
            GetComponent<Rigidbody>().AddForce(transform.forward * 2 * Time.deltaTime);

            //see if there is also sidewards movement
            GetComponent<Rigidbody>().AddTorque(Input.GetAxis("Mouse X") * transform.up * 20);

            //see if there is also upwards/downwards movement
            GetComponent<Rigidbody>().AddTorque(Input.GetAxis("Mouse Y") * -transform.right * 20);
        }
        else
        {
            //reduce rotation energy
            GetComponent<Rigidbody>().AddTorque(-GetComponent<Rigidbody>().angularVelocity * 0.5f);

        }


    }
}
