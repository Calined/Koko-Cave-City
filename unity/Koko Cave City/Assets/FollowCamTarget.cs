using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamTarget : MonoBehaviour
{
    public bool follow = true;
    public Transform camTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            if (Vector3.Distance(transform.position, camTarget.position) > 1f)
            {
                GetComponent<Rigidbody>().AddForce((camTarget.position - transform.position) * 2 * Time.deltaTime);
            }

            if (Vector3.Distance(transform.rotation.eulerAngles, camTarget.rotation.eulerAngles) > 100f)
            {

                //  GetComponent<Rigidbody>().AddTorque((camTarget.rotation.eulerAngles - transform.rotation.eulerAngles) * 10);
            }
        }
    }
}
