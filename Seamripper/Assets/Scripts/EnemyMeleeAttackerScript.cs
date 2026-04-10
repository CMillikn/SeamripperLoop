using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeAttackerScript : MonoBehaviour
{
    private float reloadTime;
    private GameObject meleePrefab;
    private bool isReloaded;
    private float meleeDamage;
    private float meleeSize;
    public EnemyMelee enemyMelee;
    private EnemyMeleeObject enemyMeleeScript;
    public MegaEnemyTag minibossTag;

    void Start()
    {
        isReloaded = true;
        reloadTime = enemyMelee.reloadTime;
        meleeDamage = enemyMelee.weaponDamage;
        meleeSize = enemyMelee.meleeSize;
        meleePrefab = enemyMelee.meleePrefab;
    }

    void Update()
    {
        if (minibossTag.isTutorialGuy == false)
        {
            if (isReloaded)
            {
                StartCoroutine(EnemySlice());
            }
        }
    }

    IEnumerator EnemySlice()
    {
        isReloaded = false;
        GameObject instantiatedMelee = Instantiate(meleePrefab,transform.position,transform.rotation);
        enemyMeleeScript = instantiatedMelee.GetComponent<EnemyMeleeObject>();
        enemyMeleeScript.weaponType = enemyMelee;
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
    }
}
