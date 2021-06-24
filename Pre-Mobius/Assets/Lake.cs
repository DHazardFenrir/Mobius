using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    public GameObject lake;
    public float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 4 - 2;
        lake.transform.position = new Vector3(0, y, 0);
    }
}
