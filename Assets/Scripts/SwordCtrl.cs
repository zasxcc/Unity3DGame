using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tr;

    private bool isColl = false;
    private int collCount = 0;
    private float damage;
    public float speed = 100.0f;

    public ParticleSystem particle;

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


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ENEMY")
        {
            Instantiate(particle, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }  
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }
    public float GetDamage()
    {
        return damage;
    }
}
