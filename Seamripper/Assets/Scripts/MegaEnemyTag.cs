using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaEnemyTag : MonoBehaviour
{
    public float enemyHealth;
    public float enemySpeed;
    public bool isHurt;
    public GameObject playerObject;
    public Rigidbody rb;
    
    //1 is melee, 2 is ranged, 3 is walk, 4 is dash
    public enum limbType
    {
        melee,
        ranged,
        walk,
        dash,
    }
    public limbType currentLimb;
    public int typeOfLimb;
    public EnemyBodyManager enemyBodyManager;
    private EnemyMelee meleeArm;
    private EnemyRanged rangedArm;
    private EnemyWalk walkArm;
    private EnemyDash dashArm;
    public EnemyMeleeAttackerScript meleeAttackerScript;
    public EnemyRangedAttackerScript rangedAttackerScript;
    public EnemyWalkAttackerScript walkAttackerScript;
    public EnemyDashAttackerScript dashAttackerScript;
    public GameObject deathSplash;
    
    void Start()
    {
        int randomIndex = Random.Range(1, 5);
        if (randomIndex == 1)
        {
            currentLimb = limbType.melee;
            typeOfLimb = Random.Range(2, 5);
            meleeArm = enemyBodyManager.MeleeArsenal[typeOfLimb];
            rangedAttackerScript.enabled = false;
            walkAttackerScript.enabled = false;
            dashAttackerScript.enabled = false;
        }
        else if (randomIndex == 2)
        {
            currentLimb = limbType.ranged;
            typeOfLimb = Random.Range(2, 5);
            rangedArm = enemyBodyManager.RangedArsenal[typeOfLimb];
            meleeAttackerScript.enabled = false;
            walkAttackerScript.enabled = false;
            dashAttackerScript.enabled = false;
        }
        else if (randomIndex == 3)
        {
            currentLimb = limbType.walk;
            typeOfLimb = 2;
            walkArm = enemyBodyManager.WalkArsenal[typeOfLimb];
            meleeAttackerScript.enabled = false;
            rangedAttackerScript.enabled = false;
            dashAttackerScript.enabled = false;
        }
        else
        {
            currentLimb = limbType.dash;
            typeOfLimb = Random.Range(2, 5);
            dashArm = enemyBodyManager.DashArsenal[typeOfLimb];
            meleeAttackerScript.enabled = false;
            rangedAttackerScript.enabled = false;
            walkAttackerScript.enabled = false;
        }
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
                //Movement stuff
                Vector3 moveDirection = new Vector3(playerObject.transform.position.x, this.transform.position.y, playerObject.transform.position.z);
                transform.LookAt(moveDirection);
                rb.linearVelocity = transform.forward * (enemySpeed);


            }
        }
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    public void GetHurt(float damage)
    {
        isHurt = true;
        enemyHealth = enemyHealth - damage;
        rb.AddForce(new Vector3(this.transform.position.x - playerObject.transform.position.x, 0, this.transform.position.z - playerObject.transform.position.z) * (1), ForceMode.Impulse);
        if (enemyHealth <= 0)
        {
            GetKilled();
        }
        StartCoroutine(hurtWait());
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
