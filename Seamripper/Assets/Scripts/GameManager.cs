using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public PlayerBodyManager playerBodyManager;
    public GameObject playerObject;
    public int numberOfBossesKilled;
    public int numberOfBossesInExistence;
    public int bossStage = 1;
    public bool canSpawnBosses;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("FUUUUCK NO GAMEMANAGER");
            }
            return instance;
        }
    }

    private void Awake()
    {
        numberOfBossesKilled = 0;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossStage != 1)
        {
            if (numberOfBossesInExistence == 0)
            {
                canSpawnBosses = true;
            }
        }
        if (numberOfBossesKilled == 6)
        {
            SceneManager.LoadScene(2);
        }
    }
}
