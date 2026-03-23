using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    Keyboard _thisKb;
    Rigidbody _thisRb;
    public GameObject playerObject;
    public GameObject aimingObject;
    public GameObject dashObject;
    public float thisAccel;
    public float thisSpeed;
    //Dash speeds
    public float dashTime;

    bool isDashing;
    public float currentSpeed;


    public float headbangSpeed;
    bool isHeadbanging;
    public float headbangStartup;
    public float headbangCooldown;
    public GameObject headbangObject;
    public GameObject bodyParts;
    GameObject instancedHeadbangGO;


    
    void Start()
    {

        _thisKb = Keyboard.current;
        _thisRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (instancedHeadbangGO != null)
        {
            instancedHeadbangGO.transform.position = playerObject.transform.position;
            instancedHeadbangGO.transform.localEulerAngles = playerObject.transform.localEulerAngles;
        }
        
        if (isHeadbanging == false)
        {
            playerObject.transform.LookAt(new Vector3(aimingObject.transform.position.x, playerObject.transform.position.y, aimingObject.transform.position.z));
        }

        if (isHeadbanging == false && _thisKb.spaceKey.wasPressedThisFrame)
        {
            StartCoroutine(HeadbangCoroutine());
        }

        IEnumerator HeadbangCoroutine()
        {
            isHeadbanging = true;
            bodyParts.SetActive(false);
            yield return new WaitForSeconds(headbangStartup);
            instancedHeadbangGO = Instantiate(headbangObject, playerObject.transform.position, Quaternion.identity);
            Vector3 dashDirection = dashObject.transform.position - playerObject.transform.position;
            _thisRb.AddForce(dashDirection * headbangSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(headbangCooldown);
            bodyParts.SetActive(true);
            isHeadbanging = false;
            GameManager.Instance.playerBodyManager.ReloadEverything();
        }
    }
}
