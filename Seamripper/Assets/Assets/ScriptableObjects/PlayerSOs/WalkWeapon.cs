using UnityEngine;

[CreateAssetMenu(fileName = "WalkWeapon", menuName = "Scriptable Objects/WalkWeapon")]
public class WalkWeapon : ScriptableObject
{
    public float walkSpeed;
    public string weaponName;
    public float walkAccel;
    public float walkDecel;
    public bool isStepper;
    public bool isLimper;
    public int stepAmount;
    public int limpAmount;
    public float weaponDurability;
    public Mesh weaponVis;
}
