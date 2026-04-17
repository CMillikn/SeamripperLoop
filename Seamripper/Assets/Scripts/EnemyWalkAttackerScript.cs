using UnityEngine;

public class EnemyWalkAttackerScript : MonoBehaviour
{
    public EnemyWalk enemyWalk;
    public MegaEnemyTag minibossTag;
    public BossScript bossScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (minibossTag != null)
        {
            if (minibossTag.isTutorialGuy == false)
            {
                minibossTag.enemySpeed = minibossTag.enemySpeed * 2;
            }
        }
        else if (bossScript != null)
        {
            if (bossScript.isTutorialGuy == false)
            {
                bossScript.enemySpeed = bossScript.enemySpeed * 2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
