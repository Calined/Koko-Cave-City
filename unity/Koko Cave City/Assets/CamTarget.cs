using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    IEnumerator FindNewPosition(float secondsBetweenFinds)
    {
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        yield return new WaitForSeconds(secondsBetweenFinds);
        StartCoroutine(FindNewPosition(secondsBetweenFinds));
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FindNewPosition(20f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
