using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float spinSpeed;
    public bool canSpawn;
    public bool canMegaSpawn;
    public GameObject enemyObj;
    public GameObject megaEnemyObj;
    public GameObject spawnPoint;
    public float spawnWait;
    public float spawnVariance;

    public float megaSpawnWait;
    public float megaSpawnVariance;
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

        if (canMegaSpawn)
        {
            StartCoroutine(SpawnMegaGoon());
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

    IEnumerator SpawnMegaGoon()
    {
        canMegaSpawn = false;
        Instantiate(megaEnemyObj, spawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(megaSpawnWait - megaSpawnVariance, megaSpawnWait + megaSpawnVariance));
        canMegaSpawn = true;
    }
}
