using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCrtl : MonoBehaviour
{
    public Transform tr;
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(Vector3.back * Time.deltaTime * 2, Space.Self);
    }
}
