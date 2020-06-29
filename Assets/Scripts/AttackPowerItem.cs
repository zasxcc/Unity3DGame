using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerItem : MonoBehaviour
{
    private Transform tr;
    private float rotateSpeed = 10;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.rotation = Quaternion.Euler(new Vector3(180, rotateSpeed, 0));
        rotateSpeed += 10;
    }
}
