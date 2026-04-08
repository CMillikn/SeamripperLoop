using UnityEngine;

[CreateAssetMenu(fileName = "DashWeapon", menuName = "Scriptable Objects/DashWeapon")]
public class DashWeapon : ScriptableObject
{
    public float dashDistance;
    public float dashSpeed;
    public float dashCooldown;
    public float dashInvulnTimer;
    public GameObject dashStartObject;
    public GameObject dashFollowerObject;
    public GameObject dashLandObject;
    public string weaponName;
    public Mesh weaponVis;
    public float weaponDurability;
}
