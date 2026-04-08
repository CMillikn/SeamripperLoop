using System.Collections;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    EnemyScript enemyTag;
    MegaEnemyTag minibossTag;
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
        minibossTag = col.gameObject.GetComponent<MegaEnemyTag>();
        if (enemyTag != null)
        {
            enemyTag.GetMeleeHurt(WeaponType.weaponDamage);
        }
        if (minibossTag != null)
        {
            minibossTag.GetMeleeHurt(WeaponType.weaponDamage);
        }
    }
}
