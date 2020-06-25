using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tr;
    public float damage = 10.0f;
    public float speed = 100.0f;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    void Start()
    {
        //GetComponent<Rigidbody>().AddForce(transform.up * speed* -1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(Vector3.up * speed * -1 * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ENEMY")
        {
            gameObject.SetActive(false);
            
        }
    }
}
