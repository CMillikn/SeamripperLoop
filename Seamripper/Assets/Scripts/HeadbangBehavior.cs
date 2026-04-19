using System.Collections;
using UnityEngine;

public class HeadbangBehavior : MonoBehaviour
{
    EnemyScript enemyTag;
    MegaEnemyTag minibossTag;
    private BossScript bossTag;
    public bool headbangCooldown;
    void Start()
    {
        this.transform.position = GameManager.Instance.playerObject.transform.position;
        this.transform.localRotation = GameManager.Instance.playerObject.transform.localRotation;
    }

    private void OnCollisionEnter(Collision col)
    {
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        minibossTag = col.gameObject.GetComponent<MegaEnemyTag>();
        PlayerBodyManager bodyMan = GameManager.Instance.playerBodyManager;

        if (enemyTag != null)
        {
            enemyTag.GetKilled();
        }
        if (minibossTag != null)
        {
            if (!headbangCooldown)
            {
                if (minibossTag.enemyHealth - 15 <= 0)
                {
                    if (minibossTag.currentLimb == MegaEnemyTag.limbType.melee)
                    {
                        bodyMan.ChangeMelee(bodyMan.MeleeArsenal[minibossTag.typeOfLimb]);
                        minibossTag.GetKilled();
                    }
                    else if (minibossTag.currentLimb == MegaEnemyTag.limbType.ranged)
                    {
                        bodyMan.ChangeRanged(bodyMan.RangedArsenal[minibossTag.typeOfLimb]);
                        minibossTag.GetKilled();
                    }
                    else if (minibossTag.currentLimb == MegaEnemyTag.limbType.walk)
                    {
                        bodyMan.ChangeWalk(bodyMan.WalkArsenal[minibossTag.typeOfLimb]);
                        minibossTag.GetKilled();
                    }
                    else
                    {
                        bodyMan.ChangeDash(bodyMan.DashArsenal[minibossTag.typeOfLimb]);
                        minibossTag.GetKilled();
                    }
                }
                else
                {
                    minibossTag.GetHurt(15);
                }
            }
        }

        if (bossTag != null)
        {
            if (!headbangCooldown)
            {
                if (bossTag.enemyHealth - 15 <= 0)
                {
                    bodyMan.ChangeMelee(bodyMan.MeleeArsenal[bossTag.typeOfLimb]);
                    bodyMan.ChangeRanged(bodyMan.RangedArsenal[bossTag.typeOfLimb]);
                    bodyMan.ChangeDash(bodyMan.DashArsenal[bossTag.typeOfLimb]);
                    bodyMan.ChangeWalk(bodyMan.WalkArsenal[bossTag.typeOfLimb]);
                    bossTag.GetKilled();
                }
                else
                {
                    bossTag.GetHurt(15);
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        headbangCooldown = true;
        yield return new WaitForSeconds(1);
        headbangCooldown = false;
    }
}
