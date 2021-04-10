using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("InteractableInfo")]
    [SerializeField] float sphereCastRadius = 0.5f;
    [SerializeField] int interactableLayerIndex;
    private Vector3 raycastPos;
    [SerializeField] GameObject lookObject;
    private PhysicsObject physicsObject;
    private Camera mainCamera;

    [Header("Pickup")]
    [SerializeField] Transform pickupParent;
    [SerializeField] GameObject currentlyPickedObject;
    private Rigidbody pickupRB;

    [Header("ObjectFollow")]
    [SerializeField] private float minSpeed = 0;
    [SerializeField] private float maxSpeed = 300f;
    [SerializeField] private float maxDistance = 10f;
    private float currentSpeed = 0f;
    private float currentDist = 0f;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 100f;
    Quaternion lookRot;

    private void Start()
    {
        mainCamera =Camera.main;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pickupParent.position, 0.5f);
    }

    private void Update()
    {
        raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, 1 << interactableLayerIndex))
        {
            lookObject = hit.collider.transform.root.gameObject;
            if (lookObject.GetComponent<Rigidbody>() == null) return;

        }
        else
        {
            lookObject = null;
        }

        //press button
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentlyPickedObject == null)
            {
                if (lookObject != null)
                {
                    PickupObject();
                }
            }
            else
            {
                BreakConnection();
            }
        }
        if (currentlyPickedObject != null && currentDist > maxDistance) BreakConnection();
    }

    private void FixedUpdate()
    {
        if(currentlyPickedObject != null)
        {
            currentDist = Vector3.Distance(pickupParent.position, pickupRB.position);
            currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, currentDist / maxDistance);
            currentSpeed *= Time.fixedDeltaTime;
            Vector3 direction = pickupParent.position - pickupRB.position;
            pickupRB.velocity = direction.normalized * currentSpeed;

            //Rotation
            lookRot = Quaternion.LookRotation(mainCamera.transform.position - pickupRB.position);
            lookRot = Quaternion.Slerp(mainCamera.transform.rotation, lookRot, rotationSpeed * Time.fixedDeltaTime);
            pickupRB.MoveRotation(lookRot);

        }
        
    }

    void PickupObject()
    {
        physicsObject = lookObject.GetComponent<PhysicsObject>();
        
        currentlyPickedObject = lookObject;
        pickupRB = currentlyPickedObject.GetComponent<Rigidbody>();
        pickupRB.constraints = RigidbodyConstraints.FreezeRotation;
       
        physicsObject.playerInteractions = this;
        StartCoroutine(physicsObject.PickUp());

      

    }

   public void BreakConnection()
    {
        pickupRB.constraints = RigidbodyConstraints.None;
        currentlyPickedObject = null;
        physicsObject.pickedUp = false;
       
        currentDist = 0;

    }

}
