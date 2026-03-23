using UnityEngine;
using System.Collections;
public class ShotgunScript : MonoBehaviour
{
    public float bulletLifetime;
    public float bulletSpeed;
    public Rigidbody bulletRb;
    public GameObject bulletDeath;
    EnemyScript enemyTag;
    public RangedWeapon WeaponType { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.localEulerAngles = new Vector3 (0f, this.transform.localEulerAngles.y + Random.Range(-15,15), 0f);
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
        bulletRb.linearVelocity = transform.forward * ((WeaponType.bulletSpeed * Time.deltaTime) * 100);
    }

    private void OnCollisionEnter(Collision col)
    {
        StartCoroutine(HitThing());
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        if (enemyTag != null)
        {
            enemyTag.GetHurt(WeaponType.weaponDamage);
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
