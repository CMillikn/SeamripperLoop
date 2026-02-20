using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedArmScript : MonoBehaviour
{
    public GameObject playerGO;
    bool reloaded=true;
    Mouse currentMouse;
    [SerializeField] GameObject bulletPrefab;
    public RangedWeapon rangedWeaponType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMouse = Mouse.current;   
    }

    // Update is called once per frame
    void Update()
    {
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
            var projectile = Instantiate(bulletPrefab, playerGO.transform.position, playerGO.transform.rotation);
            projectile.GetComponent<BulletBehavior>().WeaponType = rangedWeaponType;
            yield return new WaitForSeconds(rangedWeaponType.weaponBurstDowntime);
        }
        yield return new WaitForSeconds(rangedWeaponType.weaponDowntime);
        reloaded = true;
    }
}
