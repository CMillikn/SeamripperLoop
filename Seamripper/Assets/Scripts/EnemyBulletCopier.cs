using System.Collections;
using UnityEngine;

public class EnemyBulletCopier : MonoBehaviour
{
    private MovementScript playerScript;
    public EnemyRanged weaponType { get; set; }
    public Rigidbody _rb;
    public EnemyRangedObject kingBullet;
    void Start()
    {
        weaponType = kingBullet.weaponType;
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.linearVelocity = transform.forward * (weaponType.projectileSpeed);
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
