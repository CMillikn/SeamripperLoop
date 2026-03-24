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

    void Start()
    {
        int randomIndex = Random.Range(1, 5);
        if (randomIndex == 1)
        {
            currentLimb = limbType.melee;
            typeOfLimb = Random.Range(2, 5);
            if (typeOfLimb == 2)
            {

            }
        }
        else if (randomIndex == 2)
        {
            currentLimb = limbType.ranged;
            typeOfLimb = Random.Range(2, 5);
        }
        else if (randomIndex == 3)
        {
            currentLimb = limbType.walk;
            typeOfLimb = 2;
        }
        else
        {
            currentLimb = limbType.dash;
            typeOfLimb = Random.Range(2, 5);
        }
        playerObject = GameManager.Instance.playerObject;
        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            if (!isHurt)
            {
                //Movement stuff
                Vector3 moveDirection = new Vector3(playerObject.transform.position.x, this.transform.position.y, playerObject.transform.position.z);
                transform.LookAt(moveDirection);
                rb.linearVelocity = transform.forward * (enemySpeed * Time.deltaTime);


            }
        }
    }

    public void GetHurt(float damage)
    {
        //if (isHurt)
        //{
        //    return;
        //}
        //else
        {

            isHurt = true;
            enemyHealth = enemyHealth - damage;
            rb.AddForce(new Vector3(this.transform.position.x - playerObject.transform.position.x, 0, this.transform.position.z - playerObject.transform.position.z) * (0.1f * damage), ForceMode.Impulse);
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
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
}
