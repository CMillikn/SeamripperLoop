using System;
using UnityEngine;
using System.Collections;

public class EnemyRangedObject : MonoBehaviour
{
    private MovementScript playerScript;
    public EnemyRanged weaponType { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SelfDestruct()
    {

        yield return new WaitForSeconds(4);
        //Instantiate(bulletDeath, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
