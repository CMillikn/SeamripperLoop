using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float spinSpeed;
    public bool canSpawn;
    public bool canMegaSpawn;
    public bool canBossSpawn;
    public int numberOfBossesToSpawn;
    public GameObject enemyObj;
    public GameObject megaEnemyObj;
    public GameObject bossEnemyObj;
    public GameObject spawnPoint;
    public float spawnWait;
    public float spawnVariance;

    public float megaSpawnWait;
    public float megaSpawnVariance;

    public float initialWait;
    public float bossSpawnWait;

    public float dangerIncrease;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(SpawnFirstBossGoon());
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnWait > 1)
        {
            spawnWait = spawnWait - (Time.deltaTime * dangerIncrease);
        }
        else
        {
            spawnWait = 1;
        }

        if (megaSpawnWait > 10)
        {
            megaSpawnWait = megaSpawnWait - (Time.deltaTime * dangerIncrease);
        }
        else
        {
            megaSpawnWait = 10;
        }


        if (canBossSpawn)
        {
            StartCoroutine(SpawnBosses());
        }
        
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

    IEnumerator SpawnFirstBossGoon()
    {
        yield return new WaitForSeconds(initialWait);
        canBossSpawn = false;
        Instantiate(bossEnemyObj, spawnPoint.transform.position, Quaternion.identity);
    }

    IEnumerator SpawnBosses()
    {
        canBossSpawn = false;
        if (numberOfBossesToSpawn > 3)
        {
            yield break;
        }
        yield return new WaitForSeconds(initialWait);
        for (int i = 0; i <numberOfBossesToSpawn; i++)
        {
            Instantiate(bossEnemyObj, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        numberOfBossesToSpawn++;
        canBossSpawn=true;
    }
}
