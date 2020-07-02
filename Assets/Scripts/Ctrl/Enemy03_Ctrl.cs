using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03_Ctrl : Enemy_Ctrl
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        moveSpeed = 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //스킬 맞았는지 검사, 
        //맞았으면 잠시 전진X
        if (!isTakeSkill)
        {
            tr.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);

        }
        //스킬 맞았는지 검사,
        //맞았으면 한바퀴 돌린다.
        if (isTakeSkill)
        {
            tr.Rotate(0.0f, rotate, 0.0f);
            Debug.Log(tr.rotation.y);
            if (tr.rotation.y == 1.0f)
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
            BulletDamaeProgress(100);
        }

        else if (collision.tag == "SKILL")
        {
            SkillDamageProgress(100);
        }

        else if (collision.tag == "PLAYER")
        {
            gameObject.SetActive(false);
        }
    }
}
