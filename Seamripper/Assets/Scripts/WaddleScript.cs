using UnityEngine;

public class WaddleScript : MonoBehaviour
{
    public bool isLeftLeg;
    public bool isForwarding;
    Quaternion startingQuarternion;
    Quaternion forwardRotate;
    Quaternion backwardRotate;
    public GameObject forwardReference;
    public GameObject backwardReference;
    public float walkSpeed;
    public Rigidbody parentRB;
    
    void Start()
    {
        startingQuarternion = this.transform.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forwardRotate = forwardReference.transform.localRotation;
        backwardRotate = backwardReference.transform.localRotation;
        if (isLeftLeg)
        {
            if (transform.localRotation == forwardRotate)
            {
                isForwarding = false;
            }
            else if (transform.localRotation == backwardRotate)
            {
                isForwarding = true;
            }
            if (parentRB.linearVelocity.magnitude >= 0.5f)
            {
                if (isForwarding)
                {
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, forwardRotate, walkSpeed);
                }
                else
                {
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, backwardRotate, walkSpeed);
                }
            }
            else
            {
                isForwarding = true;
                transform.localRotation = Quaternion.Lerp(transform.localRotation,startingQuarternion, walkSpeed);
            }
        }
        else
        {
            if (transform.localRotation == forwardRotate)
            {
                isForwarding = true;
            }
            else if (transform.localRotation == backwardRotate)
            {
                isForwarding = false;
            }
            if (parentRB.linearVelocity.magnitude >= 0.1f)
            {
                if (isForwarding)
                {
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, backwardRotate, walkSpeed);
                }
                else
                {
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, forwardRotate, walkSpeed);
                }
            }
            else
            {
                isForwarding = true;
                transform.localRotation = Quaternion.Lerp(transform.localRotation, startingQuarternion, walkSpeed);
            }
        }
    }
}
