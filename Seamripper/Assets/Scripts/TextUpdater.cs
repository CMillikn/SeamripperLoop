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
        meleeText.text = $"Melee: {meleeArmScript.meleeWeaponType.weaponName}";
        rangedText.text = $"Ranged: {rangedArmScript.rangedWeaponType.weaponName}";
        walkText.text = $"Walker: {walkLegScript.walkWeaponType.weaponName}";
        dashText.text = $"Dasher: {dashLegScript.dashWeaponType.weaponName}";
    }
}
