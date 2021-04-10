using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] float waitOnPickup = 0.2f;
    [SerializeField] float breakForce = 35f;
    public bool pickedUp = false;
    public PlayerPickUp playerInteractions;

    private void OnCollisionEnter(Collision collision)
    {
        if (pickedUp)
        {
            if(collision.relativeVelocity.magnitude > breakForce)
            {
                playerInteractions.BreakConnection();
            }
        }
    }

    public IEnumerator PickUp()
    {
        yield return new WaitForSecondsRealtime(waitOnPickup);
        pickedUp = true;
    }
}
