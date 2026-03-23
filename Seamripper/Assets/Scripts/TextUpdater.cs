using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meleeText;
    [SerializeField] MeleeArmScript meleeArmScript;

    [SerializeField] TextMeshProUGUI rangedText;
    [SerializeField] RangedArmScript rangedArmScript;

    [SerializeField] TextMeshProUGUI walkText;
    [SerializeField] WalkLegScript walkLegScript;

    [SerializeField] TextMeshProUGUI dashText;
    [SerializeField] DashLegScript dashLegScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meleeText.text = $"Current Melee: {meleeArmScript.meleeWeaponType.weaponName}";
        rangedText.text = $"Current Ranged: {rangedArmScript.rangedWeaponType.weaponName}";
        walkText.text = $"Current Walker: {walkLegScript.walkWeaponType.weaponName}";
        dashText.text = $"Current Dasher: {dashLegScript.dashWeaponType.weaponName}";
    }
}
