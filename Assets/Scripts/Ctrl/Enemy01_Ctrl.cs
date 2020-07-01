using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01_Ctrl: Enemy_Ctrl
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 30;
        moveSpeed = 6.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTakeSkill)
        {
            tr.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
        }
        if (isTakeSkill)
        {
            tr.Rotate(0.0f, rotate, 0.0f);
            Debug.Log(tr.rotation.y);
            if(tr.rotation.y == 1.0f)
            {
                isTakeSkill = false;
                tr.rotation.Set(0.0f, 180.0f, 0.0f, 0.0f);
            }
        }
    }

    new void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BULLET")
        {
            BulletDamaeProgress(10);
        }
        else if(collision.tag == "SKILL")
        {
            SkillDamageProgress(10);
        }

        else if (collision.tag == "PLAYER")
        {
            gameObject.SetActive(false);
        }
    }
}
