using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private int life = 0;
    // Start is pcalled before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        life++;
        if(life>=60)
        {
            Destroy(gameObject);
        }
    }
}
