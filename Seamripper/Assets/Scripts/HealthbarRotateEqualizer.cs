using UnityEngine;

public class HealthbarRotateEqualizer : MonoBehaviour
{
    public GameObject enemyRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles = new Vector3(0, -enemyRotation.transform.localEulerAngles.y, 0);
    }
}
