using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    public float intervalSeconds = 1f;
    public float delaySeconds = 1f;

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(FindNewPosition(intervalSeconds));
    }

    IEnumerator FindNewPosition(float secondsBetweenFinds)
    {
        transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        yield return new WaitForSeconds(secondsBetweenFinds);
        StartCoroutine(FindNewPosition(secondsBetweenFinds));
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Wait(delaySeconds));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
