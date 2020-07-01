using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : MonoBehaviour
{
    private Transform tr;
    private float damage;
    public float speed = 20.0f;

    public ParticleSystem particle;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(Vector3.up * speed * 1 * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ENEMY")
        {
            Vector3 v;
            v.x = 0.0f;
            v.y = 90.0f;
            v.z = 0.0f;

            Vector3 position = tr.position;
            position.y = position.y - 1.0f;
            Instantiate(particle, position, Quaternion.LookRotation(v));
            gameObject.SetActive(false);
        }
    }
}
