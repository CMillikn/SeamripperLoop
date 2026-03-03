using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    EnemyScript enemyTag;
    public MeleeWeapon WeaponType { get; set; }

    private void Update()
    {
        //this.transform.localScale = new Vector3(WeaponType.weaponRange, WeaponType.weaponRange, WeaponType.weaponRange);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        if (enemyTag != null)
        {
            Destroy(enemyTag.gameObject);
        }
    }
}
