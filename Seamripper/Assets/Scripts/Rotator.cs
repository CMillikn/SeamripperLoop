using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float spinSpeed;
    public bool canSpawn;
    public GameObject enemyObj;
    public GameObject spawnPoint;
    public float spawnWait;
    public float spawnVariance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnGoon());
        }
        transform.localEulerAngles = new Vector3 (0, transform.localEulerAngles.y + (spinSpeed * Time.deltaTime), 0);
    }

    IEnumerator SpawnGoon()
    {
        canSpawn = false;
        Instantiate(enemyObj, spawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(spawnWait - spawnVariance, spawnWait + spawnVariance));
        canSpawn = true;
    }
}
