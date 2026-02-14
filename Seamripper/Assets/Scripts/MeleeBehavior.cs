using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    EnemyScript enemyTag;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        enemyTag = col.gameObject.GetComponent<EnemyScript>();
        if (enemyTag != null)
        {
            Destroy(enemyTag.gameObject);
        }
    }
}
