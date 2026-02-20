using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class BulletBehavior : MonoBehaviour
{
    public float bulletLifetime;
    public float bulletSpeed;
    public Rigidbody bulletRb;
    public GameObject bulletDeath;
    EnemyScript enemyTag;
    public RangedWeapon WeaponType { get;  set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.linearVelocity = transform.forward * ((WeaponType.bulletSpeed * Time.deltaTime)*100);
    }

    private void OnCollisionEnter(Collision col)
    {
        StartCoroutine(HitThing());
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        if (enemyTag != null)
        {
            Destroy(enemyTag.gameObject);
        }
    }



    IEnumerator SelfDestruct()
    {

        yield return new WaitForSeconds(WeaponType.weaponRange);
        Instantiate(bulletDeath, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator HitThing()
    {
        Instantiate(bulletDeath, this.transform.position, Quaternion.identity);
        yield return null;
        Destroy(gameObject);
    }
}
