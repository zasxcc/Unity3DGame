using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02_Ctrl : Enemy_Ctrl
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 50.0f;
        moveSpeed = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BULLET")
        {
            PlayerCtrl pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
            Score sc = GameObject.Find("Score").GetComponent<Score>();
            takeDamage = pc.attackPower;

            HP -= takeDamage;
            if (HP <= 0)
            {
                sc.AddScore(20);
                itemDrop = Random.Range(0, 2);
                if (itemDrop == attackPowerDrop)
                {
                    Instantiate(attackPowerItem, tr.position, tr.rotation);
                }
                else if (itemDrop == attackSpeedDrop)
                {
                    Instantiate(attackSpeedItem, tr.position, tr.rotation);
                }
                Vector3 v = tr.position;
                v.y = v.y + 1.0f;
                Instantiate(deathEffect, v, tr.rotation);
                gameObject.SetActive(false);
            }
        }

        else if (collision.tag == "PLAYER")
        {
            gameObject.SetActive(false);
        }
    }
}
