using UnityEngine;
using UnityEngine.InputSystem;

public class WalkLegScript : MonoBehaviour
{


    Keyboard _thisKb;
    public Rigidbody _thisRb;
    public WalkWeapon walkWeaponType;
    public DashLegScript dashLegType;
    public float currentSpeed;
    public bool isDashing;
    public bool canStep;
    public WalkWeapon damagedWalk;
    public float weaponHealth;
    void Start()
    {
        _thisKb = Keyboard.current;
    }


    void FixedUpdate()
    {
        float thisSpeed = walkWeaponType.walkSpeed;
        float thisAccel = walkWeaponType.walkAccel;
        _thisRb.linearDamping = walkWeaponType.walkDecel;
        currentSpeed = _thisRb.linearVelocity.magnitude;
        isDashing = dashLegType.isDashing;

        if (weaponHealth <= 0)
        {
            GameManager.Instance.playerBodyManager.currentWalkIndex = 0;
            GameManager.Instance.playerBodyManager.ChangeWalk(damagedWalk);
        }

        if ((isDashing == false) && (walkWeaponType.isStepper == false))
        {
            if (_thisRb.linearVelocity.magnitude > thisSpeed)
            {
                _thisRb.linearVelocity = Vector3.ClampMagnitude(_thisRb.linearVelocity, thisSpeed);
            }
            if (_thisKb.wKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3(_thisRb.linearVelocity.x, 0, (_thisRb.linearVelocity.z + thisAccel));
            }

            if (_thisKb.sKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3(_thisRb.linearVelocity.x, 0, (_thisRb.linearVelocity.z - thisAccel ));
            }

            if (_thisKb.aKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3((_thisRb.linearVelocity.x - thisAccel ), 0, _thisRb.linearVelocity.z);
            }

            if (_thisKb.dKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3((_thisRb.linearVelocity.x + thisAccel ), 0, _thisRb.linearVelocity.z);
            }
        }
        else if (walkWeaponType.isStepper)
        {
            //code goes here for step walking
        }
        else
        {

        }
    }
}
