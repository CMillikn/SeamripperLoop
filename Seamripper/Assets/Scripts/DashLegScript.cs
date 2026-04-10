using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashLegScript : MonoBehaviour
{
    public float dashTime;
    public float dashSpeed;
    public bool isDashing;
    public float currentSpeed;
    public GameObject playerObject;
    public GameObject aimingObject;
    public GameObject dashObject;
    public GameObject dashStart;
    public GameObject dashMid;
    public GameObject dashEnd;
    Keyboard _thisKb;
    public Rigidbody _thisRb;
    public DashWeapon dashWeaponType;
    public float weaponHealth;
    public DashWeapon damagedDash;
    GameObject instantiatedDash;
    GameObject legAnchor;
    public MeshRenderer thisMesh;
    public MovementScript movementScript;

    void Start()
    {
        _thisKb = Keyboard.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponHealth <= 0)
        {
            GameManager.Instance.playerBodyManager.currentDashIndex = 0;
            GameManager.Instance.playerBodyManager.ChangeDash(damagedDash);
        }
        if ((_thisKb.shiftKey.isPressed) && (!isDashing))
        {
            StartCoroutine(DashCoroutine());
        }
        if (instantiatedDash != null)
        {
            DashAttackScript DAScript = instantiatedDash.GetComponent<DashAttackScript>();
            DAScript.followPos = playerObject.transform.position;
        }
    }

    IEnumerator DashCoroutine()
    {
        dashStart = dashWeaponType.dashStartObject;
        dashMid = dashWeaponType.dashFollowerObject;
        isDashing = true;
        movementScript.canBeHurt = false;
        if (dashStart != null)
        {
            Instantiate(dashStart,playerObject.transform.position,Quaternion.identity);
        }
        if (dashMid != null)
        {
            instantiatedDash = Instantiate(dashMid,playerObject.transform.position, Quaternion.identity);
            instantiatedDash.transform.SetParent(playerObject.transform);
        }
        Vector3 dashDirection = dashObject.transform.position - playerObject.transform.position;
        _thisRb.AddForce(dashDirection * dashWeaponType.dashSpeed, ForceMode.Impulse);
        movementScript.canBeHurt = true;
        yield return new WaitForSeconds(dashWeaponType.dashCooldown);
        isDashing = false;
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
