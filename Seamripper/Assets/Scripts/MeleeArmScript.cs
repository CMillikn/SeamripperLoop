using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeArmScript : MonoBehaviour
{

    public GameObject playerGO;
    public bool balanced = true;
    Mouse currentMouse;
    public MeleeWeapon meleeWeaponType;
    public float weaponHealth;
    public MeleeWeapon damagedMelee;
    public MeshRenderer thisMesh;

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
            {
                GameManager.Instance.playerBodyManager.currentMeleeIndex = 0;
                GameManager.Instance.playerBodyManager.ChangeMelee(damagedMelee);
            }
        }
        if (currentMouse.rightButton.isPressed)
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
        projectile.GetComponent<MeleeBehavior>().WeaponType = meleeWeaponType;
        var meleeInstantiatedScript = projectile.GetComponent<MeleeBehavior>();
        meleeInstantiatedScript.enabled = true;
        projectile.transform.localScale = new Vector3(meleeWeaponType.weaponRange, meleeWeaponType.weaponRange, meleeWeaponType.weaponRange);
        yield return new WaitForSeconds(meleeWeaponType.weaponDowntime);
        balanced = true;
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
