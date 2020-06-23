using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float h = 0.0f;
    public float v = 0.0f;
    public float moveSpeed = 10.0f;

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
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("h = "+ h.ToString());
        Debug.Log("v = " + v.ToString());

        tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
        tr.Translate(Vector3.right * moveSpeed * h * Time.deltaTime, Space.Self);
        
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        int randomNum = 0;
        randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {
            animator.Play("Melee Right Attack 03");
        }
        else if (randomNum == 1)
        {
            animator.Play("Melee Right Attack 01");
        }

    }
}
