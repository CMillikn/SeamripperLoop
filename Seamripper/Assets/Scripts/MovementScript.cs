using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    Keyboard _thisKb;
    Rigidbody _thisRb;
    public GameObject playerObject;
    public GameObject aimingObject;
    public GameObject dashObject;
    public float thisAccel;
    public float thisSpeed;
    //Dash speeds
    public float dashTime;

    bool isDashing;
    public float currentSpeed;


    public float headbangSpeed;
    bool isHeadbanging;
    public float headbangStartup;
    public float headbangCooldown;
    public GameObject headbangObject;
    public GameObject bodyParts;
    
    GameObject instancedHeadbangGO;

    public float InvulnTimer;
    public bool canBeHurt;

    EnemyScript enemyScript;
    MegaEnemyTag minibossTag;
    EnemyMeleeObject enemyMeleeScript;
    EnemyRangedObject enemyRangedScript;

    public MeleeArmScript meleeArmScript;
    public RangedArmScript rangedArmScript;
    public DashLegScript dashLegScript;
    public WalkLegScript walkLegScript;
    
    void Start()
    {

        _thisKb = Keyboard.current;
        _thisRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (instancedHeadbangGO != null)
        {
            instancedHeadbangGO.transform.position = playerObject.transform.position;
            instancedHeadbangGO.transform.localEulerAngles = playerObject.transform.localEulerAngles;
        }
        
        if (isHeadbanging == false)
        {
            playerObject.transform.LookAt(new Vector3(aimingObject.transform.position.x, playerObject.transform.position.y, aimingObject.transform.position.z));
        }

        if (isHeadbanging == false && _thisKb.spaceKey.wasPressedThisFrame)
        {
            StartCoroutine(HeadbangCoroutine());
        }

        IEnumerator HeadbangCoroutine()
        {
            isHeadbanging = true;
            canBeHurt = false;
            bodyParts.SetActive(false);
            _thisRb.mass = 100;
            yield return new WaitForSeconds(headbangStartup);
            instancedHeadbangGO = Instantiate(headbangObject, playerObject.transform.position, Quaternion.identity);
            Vector3 dashDirection = dashObject.transform.position - playerObject.transform.position;
            _thisRb.AddForce(dashDirection * headbangSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(headbangCooldown);
            bodyParts.SetActive(true);
            isHeadbanging = false;
            canBeHurt = true;
            _thisRb.mass = 1;
            GameManager.Instance.playerBodyManager.ReloadEverything();
        }
    }

    IEnumerator GetHurt(float damage)
    {
        canBeHurt = false;
        int randomChoice = Random.Range(1, 5);
        if (randomChoice == 1)
        {
            meleeArmScript.GetHurt(damage);
        }
        else if (randomChoice == 2)
        {
            rangedArmScript.GetHurt(damage);
        }
        else if (randomChoice == 3)
        {
            dashLegScript.GetHurt(damage);
        }
        else
        {
            walkLegScript.GetHurt(damage);
        }
        yield return new WaitForSeconds(InvulnTimer);
        canBeHurt = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (canBeHurt)
        {
            minibossTag = col.gameObject.GetComponent<MegaEnemyTag>();
            enemyScript = col.gameObject.GetComponent<EnemyScript>();
            enemyMeleeScript = col.gameObject.GetComponent<EnemyMeleeObject>();
            enemyRangedScript = col.gameObject.GetComponent<EnemyRangedObject>();
            if (minibossTag != null)
            {
                StartCoroutine(GetHurt(minibossTag.contactDamage));
            }
            else if (enemyScript != null)
            {
                StartCoroutine(GetHurt(enemyScript.contactDamage));
            }
            else if (enemyMeleeScript != null)
            {
                StartCoroutine(GetHurt(enemyMeleeScript.weaponType.weaponDamage));
            }
            else if (enemyRangedScript != null)
            {
                StartCoroutine(GetHurt(enemyRangedScript.weaponType.weaponDamage));
            }
        }
    }
}
