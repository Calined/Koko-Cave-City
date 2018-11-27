using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamTarget : MonoBehaviour
{
    public bool follow = true;
    public Transform camPositionTarget;
    public Transform camLookAtTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            //position
            if (Vector3.Distance(transform.position, camPositionTarget.position) > 1f)
            {
                GetComponent<Rigidbody>().AddForce((camPositionTarget.position - transform.position) * 2 * Time.deltaTime);
            }

            //look at
            Vector3 targetDelta = camLookAtTarget.position - transform.position;

            //get the angle between transform.forward and target delta
            float angleDiff = Vector3.Angle(transform.forward, targetDelta);

            // get its cross product, which is the axis of rotation to
            // get from one vector to the other
            Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

            // apply torque along that axis according to the magnitude of the angle.
            GetComponent<Rigidbody>().AddTorque(cross * angleDiff * 1f);

        }
    }
}
