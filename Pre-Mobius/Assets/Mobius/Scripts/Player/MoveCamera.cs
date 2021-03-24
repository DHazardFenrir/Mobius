using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Transform camara;

    private float timer;
    private int int_timer;
    private float zRotation;
    private float wantedZ;
    private float timeSpeed = 2;
    private float timerToRotatez = default;

    [SerializeField] float mouseSensitvity = 0;

    private float rotationYVelocity, cameraXVelocity;
    [HideInInspector] float yRotationSpeed = default, xCameraSpeed = default;
    private float wantedYRotation;
    private float currentYRotation;
    private float wantedCameraXRotation;
    private float currentCameraXRotation;
    [SerializeField] float topAngleView = 60;
    [SerializeField] float bottomAngleView = -45;




    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camara = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {

        MouseInputMovement();
        CamMove();
    }

    void FixedUpdate()
    {
        ApplyingStuff();
    }

    void CamMove()
    {
        timer += (timeSpeed * Time.deltaTime);
        int_timer = Mathf.RoundToInt(timer);
        if (int_timer % 2 == 0)
        {
            wantedZ = -1;
        }
        else
        {
            wantedZ = 1;
        }

        zRotation = Mathf.Lerp(zRotation, wantedZ, Time.deltaTime * timerToRotatez);
    }

    void MouseInputMovement()
    {
        wantedYRotation += Input.GetAxis("Mouse X") * mouseSensitvity;

        wantedCameraXRotation -= Input.GetAxis("Mouse Y") * mouseSensitvity;

        wantedCameraXRotation = Mathf.Clamp(wantedCameraXRotation, bottomAngleView, topAngleView);
    }

    void ApplyingStuff()
    {

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, yRotationSpeed);
        currentCameraXRotation = Mathf.SmoothDamp(currentCameraXRotation, wantedCameraXRotation, ref cameraXVelocity, xCameraSpeed);



        transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
        camara.localRotation = Quaternion.Euler(currentCameraXRotation, 0, zRotation);

    }
}
