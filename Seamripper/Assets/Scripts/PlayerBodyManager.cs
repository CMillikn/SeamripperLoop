using UnityEngine;
using System.Collections.Generic;
public class PlayerBodyManager : MonoBehaviour
{
    
    public List<MeleeWeapon> MeleeArsenal = new List<MeleeWeapon>();
    public List<RangedWeapon> RangedArsenal = new List<RangedWeapon>();

    [SerializeField] MeleeArmScript meleeArmScript;
    [SerializeField] RangedArmScript rangedArmScript;

    public void ChangeMelee(MeleeWeapon melee)
    {
        meleeArmScript.meleeWeaponType = melee;
    }

    public void ChangeRanged(RangedWeapon ranged)
    {
        rangedArmScript.rangedWeaponType = ranged;
    }

    public void ChangeWalk()
    {

    }

    public void ChangeDash()
    {

    }
}
