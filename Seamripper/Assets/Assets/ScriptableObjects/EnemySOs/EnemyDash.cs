using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDash", menuName = "Scriptable Objects/EnemyDash")]
public class EnemyDash : ScriptableObject
{
    public string weaponName;
    public float dashSpeed;
    public float dashCooldown;
    public GameObject dashObject;
    public Mesh weaponVis;
}
