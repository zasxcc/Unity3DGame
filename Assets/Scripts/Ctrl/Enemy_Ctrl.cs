﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ctrl : MonoBehaviour
{
    protected float h = 0.0f;
    protected float v = 0.0f;
    protected float moveSpeed = 6.0f;
    protected float HP = 30.0f;
    protected bool isTakeSkill = false;
    protected float rotate = 10.0f;
    protected float rotateY = 0.0f;

    protected int attackSpeedDrop = 0;
    protected int attackPowerDrop = 1;
    protected int itemDrop = 0;
    protected Transform tr;
    protected Animator enemyAnimator;

    public GameObject attackPowerItem;
    public GameObject attackSpeedItem;
    public GameObject deathEffect;
    Transform t;


    protected float takeDamage;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    protected void OnTriggerEnter(Collider collision)
    {
        
    }
    protected void SkillDamageProgress(int score)
    {
        PlayerCtrl pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        enemyAnimator.Play("Take Damage");

        takeDamage = pc.attackPower * 1.5f;
        isDeath(takeDamage, score);

        isTakeSkill = true;
    }

    protected void BulletDamaeProgress(int score)
    {
        PlayerCtrl pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        enemyAnimator.Play("Take Damage");

        tr.Translate(Vector3.forward * -1 * 1, Space.Self);

        takeDamage = pc.attackPower;
        isDeath(takeDamage, score);
    }

    protected void DropItem()
    {
        itemDrop = Random.Range(0, 2);
        if (itemDrop == attackPowerDrop)
        {
            Instantiate(attackPowerItem, tr.position, tr.rotation);
        }
        else if (itemDrop == attackSpeedDrop)
        {
            Instantiate(attackSpeedItem, tr.position, tr.rotation);
        }
    }

    protected void isDeath(float damage, int score)
    {
        Score sc = GameObject.Find("Score").GetComponent<Score>();
        HP -= damage;
        if (HP <= 0)
        {
            sc.AddScore(score);
            DropItem();
            Vector3 v = tr.position;
            v.y = v.y + 1.0f;
            Instantiate(deathEffect, v, tr.rotation);
            gameObject.SetActive(false);
        }
    }
}
