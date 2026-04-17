using System.Collections;
using UnityEngine;

public class EnemyRangedAttackerScript : MonoBehaviour
{
    private float reloadTime;
    private GameObject rangedPrefab;
    private bool isReloaded = true;
    private float rangedDamage;
    private int burstCount;
    private float burstDowntime;
    public EnemyRanged enemyRanged;
    public MegaEnemyTag minibossTag;
    public BossScript bossScript;

    void Start()
    {
        if (enemyRanged != null)
        {
            isReloaded = true;  
            reloadTime = enemyRanged.reloadTime;
            rangedDamage = enemyRanged.weaponDamage;
            burstCount = enemyRanged.burstAmount;
            burstDowntime = enemyRanged.burstReload;
        }
    }

    void Update()
    {
        if (minibossTag != null)
        {
            if (minibossTag.isTutorialGuy == false)
            {
                if (isReloaded)
                {
                    StartCoroutine(Shoot());
                }
            }
        }
        else if (bossScript != null)
        {
            if (bossScript.isTutorialGuy == false)
            {
                if (isReloaded)
                {
                    StartCoroutine(Shoot());
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        isReloaded = false;
        for (int i = 0; i < enemyRanged.burstAmount; i++)
        {
            var projectile = Instantiate(enemyRanged.weaponBullet, this.transform.position, this.transform.rotation);
            EnemyRangedObject enemyRangedObject = projectile.GetComponent<EnemyRangedObject>();
            if (enemyRangedObject != null)
            {
                enemyRangedObject.weaponType = enemyRanged;
            }
            yield return new WaitForSeconds(enemyRanged.burstReload);
        }
        yield return new WaitForSeconds(enemyRanged.reloadTime);
        isReloaded = true;
    }
}
