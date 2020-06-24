using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage = 10.0f;
    public float speed = 100.0f;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * speed* -1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "ENEMY")
        {
            

          
            
        }
    }
}
