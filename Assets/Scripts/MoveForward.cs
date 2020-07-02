using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Transform tr;
    public float moveSpeed = 4.0f;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(Vector3.back * Time.deltaTime *-1* moveSpeed, Space.Self);
    }
}
