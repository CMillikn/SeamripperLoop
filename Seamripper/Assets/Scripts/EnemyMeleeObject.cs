using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyMeleeObject : MonoBehaviour
{
    private MovementScript playerScript;

    public EnemyMelee weaponType { get; set; }

    void Start()
    {
        this.transform.localScale = new Vector3(weaponType.meleeSize, weaponType.meleeSize, weaponType.meleeSize);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        playerScript = col.gameObject.GetComponent<MovementScript>();
        if (playerScript != null)
        {
            Debug.Log("Ow! I got hit.");
        }
    }
}
