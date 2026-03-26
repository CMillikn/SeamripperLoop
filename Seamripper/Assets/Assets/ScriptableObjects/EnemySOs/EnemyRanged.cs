using UnityEngine;

[CreateAssetMenu(fileName = "EnemyRanged", menuName = "Scriptable Objects/EnemyRanged")]
public class EnemyRanged : ScriptableObject
{
    public string weaponName;
    public float weaponDamage;
    public float reloadTime;
    public float projectileSpeed;
    public int burstAmount;
    public float burstReload;
}
