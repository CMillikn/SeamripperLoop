using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour
{
    public int sceneInt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneInt);
    }
}
