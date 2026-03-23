using UnityEngine;
using System.Collections.Generic;
public class PlayerBodyManager : MonoBehaviour
{
    
    public List<MeleeWeapon> MeleeArsenal = new List<MeleeWeapon>();
    public List<RangedWeapon> RangedArsenal = new List<RangedWeapon>();
    public List<WalkWeapon> WalkArsenal = new List<WalkWeapon>();
    public List<DashWeapon> DashArsenal = new List<DashWeapon>();

    [SerializeField] public MeleeArmScript meleeArmScript;
    [SerializeField] public RangedArmScript rangedArmScript;
    [SerializeField] public WalkLegScript walkLegScript;
    [SerializeField] public DashLegScript dashLegScript;

    public int currentMeleeIndex = 0;
    public int currentRangedIndex = 0;
    public int currentDashIndex = 0;
    public int currentWalkIndex = 0;

    public void ChangeMelee(MeleeWeapon melee)
    {
        meleeArmScript.meleeWeaponType = melee;
        meleeArmScript.weaponHealth = melee.weaponDurability;
        meleeArmScript.balanced = true;
    }

    public void ChangeRanged(RangedWeapon ranged)
    {
        rangedArmScript.rangedWeaponType = ranged;
        rangedArmScript.weaponHealth = ranged.weaponDurability;
        rangedArmScript.reloaded = true;
    }

    public void ChangeWalk(WalkWeapon walk)
    {
        walkLegScript.walkWeaponType = walk;
        walkLegScript.weaponHealth = walk.weaponDurability;
        walkLegScript.isDashing = false;
    }

    public void ChangeDash(DashWeapon dash)
    {
        dashLegScript.dashWeaponType = dash;
        dashLegScript.weaponHealth = dash.weaponDurability;
        dashLegScript.isDashing = false;
    }

    public void ReloadEverything()
    {
        dashLegScript.isDashing = false;
        walkLegScript.isDashing = false;
        rangedArmScript.reloaded = true;
        meleeArmScript.balanced = true;
    }
}
