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
    public MeshRenderer thisMesh;


    void Start()
    {
        currentMouse = Mouse.current;   
    }

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

    public void GetHurt(float damage)
    {
        weaponHealth = weaponHealth - damage;
        StartCoroutine(flashArm());
    }

    IEnumerator flashArm()
    {
        for (int i = 0; i < 8; i++)
        {
            thisMesh.material.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            thisMesh.material.color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
