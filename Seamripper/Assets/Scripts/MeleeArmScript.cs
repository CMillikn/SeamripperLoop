using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeArmScript : MonoBehaviour
{

    public GameObject playerGO;
    bool balanced = true;
    Mouse currentMouse;
    public MeleeWeapon meleeWeaponType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMouse.leftButton.wasPressedThisFrame)
        {
            if (balanced)
            {
                StartCoroutine(Slice());
            }
        }
    }

    IEnumerator Slice()
    {
        balanced = false;
        var projectile = Instantiate(meleeWeaponType.weaponAttackObject, playerGO.transform.position, playerGO.transform.rotation);
        projectile.GetComponent<MeleeBehavior>().weaponType = meleeWeaponType;
        yield return new WaitForSeconds(meleeWeaponType.weaponDowntime);
        balanced = true;
    }
}
