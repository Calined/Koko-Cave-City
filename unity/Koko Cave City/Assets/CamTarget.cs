using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    IEnumerator FindNewPositionAndRotation(float secondsBetweenFinds)
    {
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        transform.Rotate(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)));

        yield return new WaitForSeconds(secondsBetweenFinds);
        StartCoroutine(FindNewPositionAndRotation(secondsBetweenFinds));
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FindNewPositionAndRotation(100f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
