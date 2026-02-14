using System.Collections;
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
    public float dashSpeed;
    bool isDashing;
    public float currentSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _thisKb = Keyboard.current;
        _thisRb = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        playerObject.transform.LookAt(new Vector3(aimingObject.transform.position.x, playerObject.transform.position.y, aimingObject.transform.position.z));
        currentSpeed = _thisRb.linearVelocity.magnitude;
        if (isDashing)
        {
            //if ((_thisRb.linearVelocity.magnitude > dashSpeed) || (_thisRb.linearVelocity.magnitude < dashSpeed))
            //{
            //    _thisRb.linearVelocity = Vector3.zero;

            //}

        }
        else
        {
            if (_thisRb.linearVelocity.magnitude > thisSpeed)
            {
                _thisRb.linearVelocity = Vector3.ClampMagnitude(_thisRb.linearVelocity, thisSpeed);
            }
            if (_thisKb.wKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3(_thisRb.linearVelocity.x, 0, (_thisRb.linearVelocity.z + thisAccel * Time.deltaTime));
            }
    
            if (_thisKb.sKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3(_thisRb.linearVelocity.x, 0, (_thisRb.linearVelocity.z - thisAccel * Time.deltaTime));
            }
    
            if (_thisKb.aKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3((_thisRb.linearVelocity.x - thisAccel * Time.deltaTime), 0, _thisRb.linearVelocity.z);
            }
            
            if (_thisKb.dKey.isPressed)
            {
                _thisRb.linearVelocity = new Vector3((_thisRb.linearVelocity.x + thisAccel * Time.deltaTime), 0, _thisRb.linearVelocity.z);
            }

            if ((_thisKb.shiftKey.isPressed) && (!isDashing))
            {
                StartCoroutine(DashCoroutine());
            }
        }

        IEnumerator DashCoroutine()
        {
            isDashing = true;
            Vector3 dashDirection = dashObject.transform.position - playerObject.transform.position;
            _thisRb.AddForce(dashDirection * dashSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
        }
    }
}
