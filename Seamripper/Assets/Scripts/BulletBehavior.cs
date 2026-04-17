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
    private MegaEnemyTag megaEnemyTag;
    BossScript bossScript;
    public RangedWeapon WeaponType { get;  set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    void FixedUpdate()
    {
        bulletRb.linearVelocity = transform.forward * (WeaponType.bulletSpeed);
    }

    private void OnCollisionEnter(Collision col)
    {
        StartCoroutine(HitThing());
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        megaEnemyTag = col.gameObject.GetComponent<MegaEnemyTag>();
        bossScript = col.gameObject.GetComponent<BossScript>();
        if (enemyTag != null)
        {
            enemyTag.GetHurt(WeaponType.weaponDamage);
        }
        else if (megaEnemyTag != null)
        {
            megaEnemyTag.GetHurt(WeaponType.weaponDamage);
        }
        else if (bossScript != null)
        {
            bossScript.GetHurt(WeaponType.weaponDamage);
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
