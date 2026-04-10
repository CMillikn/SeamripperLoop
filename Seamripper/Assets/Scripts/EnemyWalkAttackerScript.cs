using UnityEngine;

public class EnemyWalkAttackerScript : MonoBehaviour
{
    public EnemyWalk enemyWalk;
    public MegaEnemyTag minibossTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (minibossTag.isTutorialGuy == false)
        {
            minibossTag.enemySpeed = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
