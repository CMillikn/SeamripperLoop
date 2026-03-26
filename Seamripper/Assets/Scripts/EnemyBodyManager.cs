using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBodyManager : MonoBehaviour
{
    public List<EnemyMelee> MeleeArsenal = new List<EnemyMelee>();
    public List<EnemyRanged> RangedArsenal = new List<EnemyRanged>();
    public List<EnemyWalk> WalkArsenal = new List<EnemyWalk>();
    public List<EnemyDash> DashArsenal = new List<EnemyDash>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
