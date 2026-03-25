using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMelee", menuName = "Scriptable Objects/EnemyMelee")]
public class EnemyMelee : ScriptableObject
{
    public string meleeName;
    public GameObject meleePrefab;
    public float weaponDamage;
    public float reloadTime;
    public float meleeSize;
}
