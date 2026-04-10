using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemyHealth;
    public float enemySpeed;
    public bool isHurt;
    public GameObject playerObject;
    public Rigidbody rb;
    public GameObject deathSplash;
    public float contactDamage;
    void Start()
    {
        playerObject = GameManager.Instance.playerObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerObject != null)
        {

            if (!isHurt)
            {
                Vector3 moveDirection = new Vector3(playerObject.transform.position.x, this.transform.position.y, playerObject.transform.position.z);
                transform.LookAt(moveDirection);
                rb.linearVelocity = transform.forward * (enemySpeed);
            }
        }
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    public void GetHurt(float damage)
    {
        {
            isHurt = true;
            enemyHealth = enemyHealth - damage;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(new Vector3(this.transform.position.x - playerObject.transform.position.x, 0, this.transform.position.z - playerObject.transform.position.z) * (1), ForceMode.Impulse);
            if (enemyHealth <= 0)
            {
                GetKilled();
            }
            StartCoroutine(hurtWait());
        }
    }

    public void GetMeleeHurt(float damage)
    {
        if (isHurt)
        {
            return;
        }
        else
        {

            isHurt = true;
            enemyHealth = enemyHealth - damage;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(new Vector3(this.transform.position.x - playerObject.transform.position.x, 0, this.transform.position.z - playerObject.transform.position.z) * (1), ForceMode.Impulse);
            if (enemyHealth <= 0)
            {
                GetKilled();
            }
            StartCoroutine(hurtWait());
        }
    }

    IEnumerator hurtWait()
    {
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
        rb.linearVelocity = Vector3.zero;
    }

    public void GetKilled()
    {
        Instantiate(deathSplash, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
