using System.Collections;
using UnityEngine;

public class HeadbangBehavior : MonoBehaviour
{
    EnemyScript enemyTag;
    MegaEnemyTag minibossTag;
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
            Destroy(enemyTag.gameObject);
        }
        if (minibossTag != null)
        {
            if (!headbangCooldown)
            {
                if (minibossTag.currentLimb == MegaEnemyTag.limbType.melee)
                {
                    bodyMan.ChangeMelee(bodyMan.MeleeArsenal[minibossTag.typeOfLimb]);
                }
                else if (minibossTag.currentLimb == MegaEnemyTag.limbType.ranged)
                {
                    bodyMan.ChangeRanged(bodyMan.RangedArsenal[minibossTag.typeOfLimb]);
                }
                else if (minibossTag.currentLimb == MegaEnemyTag.limbType.walk)
                {
                    bodyMan.ChangeWalk(bodyMan.WalkArsenal[minibossTag.typeOfLimb]);
                }
                else
                {
                    bodyMan.ChangeDash(bodyMan.DashArsenal[minibossTag.typeOfLimb]);
                }
                //int randomInt = Random.Range(1, 5);
                //if (randomInt == 1)
                //{
                //    if (bodyMan.currentMeleeIndex == bodyMan.MeleeArsenal.Count - 1)
                //    {
                //        return;
                //    }
                //    else
                //    {

                //        bodyMan.currentMeleeIndex++;
                //        int changeVar = bodyMan.currentMeleeIndex;
                //        bodyMan.ChangeMelee(bodyMan.MeleeArsenal[changeVar]);
                //        StartCoroutine(Cooldown());
                //    }
                //}
                //else if (randomInt == 2)
                //{
                //    if (bodyMan.currentRangedIndex == bodyMan.RangedArsenal.Count - 1)
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        bodyMan.currentRangedIndex++;
                //        int changeVar = bodyMan.currentRangedIndex;
                //        bodyMan.ChangeRanged(bodyMan.RangedArsenal[changeVar]);
                //        StartCoroutine(Cooldown());

                //    }
                //}
                //else if (randomInt == 3)
                //{
                //    if (bodyMan.currentWalkIndex == bodyMan.WalkArsenal.Count - 1)
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        bodyMan.currentWalkIndex++;
                //        int changeVar = bodyMan.currentWalkIndex;
                //        bodyMan.ChangeWalk(bodyMan.WalkArsenal[changeVar]);
                //        StartCoroutine(Cooldown());
                //    }
                //}
                //else
                //{
                //    if (bodyMan.currentDashIndex == bodyMan.DashArsenal.Count - 1)
                //    {
                //        return;
                //    }
                //    else
                //    {
                //        bodyMan.currentDashIndex++;
                //        int changeVar = bodyMan.currentDashIndex;
                //        bodyMan.ChangeDash(bodyMan.DashArsenal[changeVar]);
                //        StartCoroutine(Cooldown());
                //    }
                //}
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
