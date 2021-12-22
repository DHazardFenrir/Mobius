using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desirePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(-desirePos, Vector3.up);
        transform.rotation = rotation;
    }
}
