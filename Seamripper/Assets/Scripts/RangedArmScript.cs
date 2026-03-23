using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedArmScript : MonoBehaviour
{
    public GameObject playerGO;
    public bool reloaded=true;
    Mouse currentMouse;
    public RangedWeapon rangedWeaponType;
    public RangedWeapon damagedRanged;
    public float weaponHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMouse = Mouse.current;   
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponHealth <= 0)
        {
            GameManager.Instance.playerBodyManager.currentRangedIndex = 0;
            GameManager.Instance.playerBodyManager.ChangeRanged(damagedRanged);
        }
        //Detects for mouse click
        if (currentMouse.leftButton.isPressed)
        {
            if (reloaded)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        reloaded = false;
        for (int i = 0; i < rangedWeaponType.weaponBurst; i++)
        {
            var projectile = Instantiate(rangedWeaponType.weaponAttackObject, playerGO.transform.position, playerGO.transform.rotation);
            BulletBehavior bulletBehav = projectile.GetComponent<BulletBehavior>();
            ShotgunScript shotgunBehav = projectile.GetComponent<ShotgunScript>();
            if (bulletBehav != null)
            {
                bulletBehav.WeaponType = rangedWeaponType;
            }
            else if (shotgunBehav != null)
            {
                shotgunBehav.WeaponType = rangedWeaponType;
            }
            yield return new WaitForSeconds(rangedWeaponType.weaponBurstDowntime);
        }
        yield return new WaitForSeconds(rangedWeaponType.weaponDowntime);
        reloaded = true;
    }
}
