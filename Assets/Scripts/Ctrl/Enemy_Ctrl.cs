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

    protected AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip skillSound;

    public GameObject attackPowerItem;
    public GameObject attackSpeedItem;
    public GameObject deathEffect;
    Transform t;


    protected float takeDamage;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(skillSound);
        PlayerCtrl pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        enemyAnimator.Play("Take Damage");

        takeDamage = pc.attackPower * 0.0f;
        isDeath(takeDamage, score);

        //스킬 효과 발동
        isTakeSkill = true;
    }

    protected void BulletDamaeProgress(int score)
    {
        audioSource.PlayOneShot(hitSound);
        PlayerCtrl pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        enemyAnimator.Play("Take Damage");

        //적 밀기
        tr.Translate(Vector3.forward * -1 * 1, Space.Self);

        takeDamage = pc.attackPower;
        isDeath(takeDamage, score);
    }

    protected void DropItem()
    {
        //드랍확률 20%확률로 아이템 드랍, 
        //드랍시 50%는 공격속도 아이템, 50%는 공격력 아이템
        itemDrop = Random.Range(0, 10);
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
