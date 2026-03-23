using System.Collections;
using UnityEngine;

public class DashAttackScript : MonoBehaviour
{
    EnemyScript enemyTag;
    public float dashDamage;
    public Vector3 followPos;
    private void OnCollisionEnter(Collision col)
    {
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        if (enemyTag != null)
        {
            StartCoroutine(waitForHit(enemyTag));
        }
    }

    public void Update()
    {
        if (followPos != null)
        {
            this.transform.position = followPos;
        }
    }

    IEnumerator waitForHit(EnemyScript enemyScript)
    {
        yield return new WaitForEndOfFrame();
        enemyScript.GetHurt(dashDamage);
    }
}
