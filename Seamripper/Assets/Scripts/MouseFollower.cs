using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    public float lerpSpeed;
    Vector3 mousePosition;
    Mouse currentMouse;
    public GameObject bulletPrefab;
    public GameObject meleePrefab;
    public GameObject spawnedMeleePrefab;
    public GameObject playerGO;
    public Camera mainCam;

    public void Start()
    {
        currentMouse = Mouse.current;
    }

    // Update is called once per frame
    public void Update()
    {
        //Mouse follow behavior
        mousePosition = Input.mousePosition;
        mousePosition.z = mainCam.transform.position.y;
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);
        transform.position = Vector3.Lerp(transform.position, mousePosition, lerpSpeed * Time.deltaTime);
        
        //Detects for mouse click
        if (currentMouse.leftButton.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, playerGO.transform.position, playerGO.transform.rotation);
        }

        if (currentMouse.rightButton.wasPressedThisFrame)
        {
            spawnedMeleePrefab = Instantiate(meleePrefab, playerGO.transform.position, playerGO.transform.rotation);
            spawnedMeleePrefab.transform.SetParent(playerGO.transform);
        }
    }
}
