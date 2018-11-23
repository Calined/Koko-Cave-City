using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool holding = false;
    private Vector2 mouseStartPosition;

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
        GetComponent<Rigidbody>().AddForce(Vector3.up * 49.5f * Time.deltaTime);

        //if mouse or finger holds
        if (Input.GetMouseButton(0))
        {
            //just started holding
            if (holding == false)
            {
                holding = true;
                mouseStartPosition = Input.mousePosition;
            }

            //move forward
            GetComponent<Rigidbody>().AddForce(transform.forward * 2 * Time.deltaTime);

            //see if there is also sidewards movement
            GetComponent<Rigidbody>().AddTorque((Input.mousePosition.x - mouseStartPosition.x) * transform.up * 20 * Time.deltaTime);

            //see if there is also upwards/downwards movement
            // GetComponent<Rigidbody>().AddForce();
        }
        else
        {
            //not holding anymore
            holding = false;
        }

    }
}
