using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{

    [SerializeField] EventManager eventManager;
    public GameObject lake;
    public float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 5 - 1;
        lake.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
    }
}
