using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float waitTime;

    public void Start()
    {
        StartCoroutine(SelfYourself());
    }

    IEnumerator SelfYourself()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
