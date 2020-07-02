using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedItem : MonoBehaviour
{
    // Start is called before the first frame update
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "PLAYER")
        {
            Destroy(gameObject);
        }

    }
}
