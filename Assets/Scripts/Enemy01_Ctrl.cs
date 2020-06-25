using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01_Ctrl : MonoBehaviour
{
    public float h = 0.0f;
    public float v = 0.0f;
    public float moveSpeed = 10.0f;
    public int HP = 100;

    public Transform tr;
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(Vector3.forward * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BULLET")
        {
            HP -= 10;
            if(HP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
