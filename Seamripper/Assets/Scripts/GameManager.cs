using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public PlayerBodyManager playerBodyManager;
    public GameObject playerObject;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerBodyManager.ChangeMelee(playerBodyManager.MeleeArsenal[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerBodyManager.ChangeMelee(playerBodyManager.MeleeArsenal[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerBodyManager.ChangeMelee(playerBodyManager.MeleeArsenal[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerBodyManager.ChangeRanged(playerBodyManager.RangedArsenal[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerBodyManager.ChangeRanged(playerBodyManager.RangedArsenal[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playerBodyManager.ChangeRanged(playerBodyManager.RangedArsenal[2]);
        }
    }
}
