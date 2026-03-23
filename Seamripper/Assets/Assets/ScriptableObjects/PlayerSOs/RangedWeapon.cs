using UnityEngine;

[CreateAssetMenu(fileName = "RangedWeapon", menuName = "Scriptable Objects/RangedWeapon")]
public class RangedWeapon : ScriptableObject
{
    public string weaponName;
    public int weaponBurst;
    public float weaponDamage;
    public float weaponBurstDowntime;
    public float weaponDowntime;
    public float weaponDurability;
    public float bulletSpeed;
    public float weaponRicochet;
    public bool weaponHitscan;
    public float weaponRange;
    public GameObject weaponAttackObject;
}
