using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01_Ctrl : MonoBehaviour
{
    public float h = 0.0f;
    public float v = 0.0f;
    public float moveSpeed = 10.0f;
    public float HP = 100.0f;

    private int attackSpeedDrop = 0;
    private int attackPowerDrop = 1;
    private int itemDrop = 0;
    private Transform tr;
    private Animator animator;

    public GameObject attackPowerItem;
    public GameObject attackSpeedItem;
    public GameObject deathEffect;
    Transform t;


    float takeDamage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BULLET")
        {
            PlayerCtrl pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
            Score sc = GameObject.Find("Score").GetComponent<Score>();
            takeDamage = pc.attackPower;

            HP -= takeDamage;
            if (HP <= 0)
            {
                sc.AddScore(10);
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

        else if(collision.tag == "PLAYER")
        {
            gameObject.SetActive(false);
        }
    }
}
