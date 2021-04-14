using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    protected Vector3 posLastFame;
    [SerializeField] Camera InspectCam;

    // Start is called before the first frame update
    void Start()
    {
        if(InspectCam != null)
        InspectCam = GameObject.Find("InspectCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            posLastFame = Input.mousePosition;

        if(Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - posLastFame;
            posLastFame = Input.mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
        }
    }
}
