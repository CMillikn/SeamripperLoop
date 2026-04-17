using System.Collections;
using UnityEngine;

public class EnemyDashAttackerScript : MonoBehaviour
{
    public EnemyDash enemyDash;
    public bool canDash;
    public GameObject dashAttack;
    public GameObject dashAttackInstance;
    public Rigidbody _thisRB;
    public MegaEnemyTag minibossTag;
    public BossScript bossScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (enemyDash != null)
        {
            dashAttack = enemyDash.dashObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canDash)
        {
            if (minibossTag != null)
            {
                if (minibossTag.isTutorialGuy == false)
                {
                    StartCoroutine(Dash());
                }
            }
            else if (bossScript != null)
            {
                if (bossScript.isTutorialGuy == false)
                {
                    StartCoroutine(Dash());
                }
            }
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        if (dashAttack != null)
        {
            dashAttackInstance = Instantiate(dashAttack, transform.position, transform.rotation);
            dashAttackInstance.transform.SetParent(this.transform);
        }
        Vector3 dashDirection = (GameManager.Instance.playerObject.transform.position - this.transform.position);
        _thisRB.AddForce(dashDirection * enemyDash.dashSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(enemyDash.dashCooldown);
        canDash = true;
    }
}
