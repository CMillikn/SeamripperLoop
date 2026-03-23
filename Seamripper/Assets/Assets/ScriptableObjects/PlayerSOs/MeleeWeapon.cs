using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Scriptable Objects/MeleeWeapon")]
public class MeleeWeapon : ScriptableObject
{
    public string weaponName;
    public int weaponBurst;
    public float weaponDamage;
    public float weaponDowntime;
    public float weaponDurability;
    public float weaponRange;
    public GameObject weaponAttackObject;
}
