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

    public MeshFilter meleeArmMesh;
    public MeshFilter rangedArmMesh;
    public MeshFilter dashLegMesh;
    public MeshFilter walkLegMesh;

    public float textHeight;

    public void ChangeMelee(MeleeWeapon melee)
    {
        meleeArmScript.meleeWeaponType = melee;
        meleeArmScript.weaponHealth = melee.weaponDurability;
        meleeArmScript.balanced = true;
        meleeArmMesh.mesh = melee.weaponVis;
        if (melee.weaponGetParticle != null)
        {
            Instantiate(melee.weaponGetParticle, new Vector3(GameManager.Instance.playerObject.transform.position.x, textHeight, GameManager.Instance.playerObject.transform.position.z), Quaternion.identity);
        }

    }

    public void ChangeRanged(RangedWeapon ranged)
    {
        rangedArmScript.rangedWeaponType = ranged;
        rangedArmScript.weaponHealth = ranged.weaponDurability;
        rangedArmScript.reloaded = true;
        rangedArmMesh.mesh = ranged.weaponVis;
        if (ranged.weaponGetParticle != null)
        {
            Instantiate(ranged.weaponGetParticle, new Vector3(GameManager.Instance.playerObject.transform.position.x, textHeight, GameManager.Instance.playerObject.transform.position.z), Quaternion.identity);
        }

    }

    public void ChangeWalk(WalkWeapon walk)
    {
        walkLegScript.walkWeaponType = walk;
        walkLegScript.weaponHealth = walk.weaponDurability;
        walkLegScript.isDashing = false;
        walkLegMesh.mesh = walk.weaponVis;
        if (walk.weaponGetParticle != null)
        {
            Instantiate(walk.weaponGetParticle, new Vector3(GameManager.Instance.playerObject.transform.position.x, textHeight, GameManager.Instance.playerObject.transform.position.z), Quaternion.identity);
        }
    }

    public void ChangeDash(DashWeapon dash)
    {
        dashLegScript.dashWeaponType = dash;
        dashLegScript.weaponHealth = dash.weaponDurability;
        dashLegScript.isDashing = false;
        dashLegMesh.mesh = dash.weaponVis;
        if (dash.weaponGetParticle != null)
        {
            Instantiate(dash.weaponGetParticle, new Vector3(GameManager.Instance.playerObject.transform.position.x, textHeight, GameManager.Instance.playerObject.transform.position.z), Quaternion.identity);
        }
    }

    public void ReloadEverything()
    {
        dashLegScript.isDashing = false;
        walkLegScript.isDashing = false;
        rangedArmScript.reloaded = true;
        meleeArmScript.balanced = true;
    }


}
