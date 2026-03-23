using System.Collections;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    EnemyScript enemyTag;
    public MeleeWeapon WeaponType { get; set; }

    public void Start()
    {
        this.transform.localScale = new Vector3(WeaponType.weaponRange, WeaponType.weaponRange, WeaponType.weaponRange);
        this.transform.position = GameManager.Instance.playerObject.transform.position;
    }

    private void Update()
    {
        this.transform.localScale = new Vector3(WeaponType.weaponRange, WeaponType.weaponRange, WeaponType.weaponRange);
        this.transform.position = GameManager.Instance.playerObject.transform.position;
    }

    private void OnCollisionEnter(Collision col)
    {
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        if (enemyTag != null)
        {
            StartCoroutine(waitForHit(enemyTag));
        }
    }

    IEnumerator waitForHit(EnemyScript enemyScript)
    {
        yield return new WaitForEndOfFrame();
        enemyScript.GetHurt(WeaponType.weaponDamage);
    }
}
