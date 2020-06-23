using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float h = 0.0f;
    public float v = 0.0f;

    public Transform tr;
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
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
    }
}
