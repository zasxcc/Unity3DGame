﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject spawnEnemy;
    public float spawnTime = 2.0f;

    //오브젝트 풀
    public Enemy01_Ctrl prefab_Enemy01;
    private List<Enemy01_Ctrl> Enemy01Pool = new List<Enemy01_Ctrl>();
    //생성 갯수
    private readonly int Enemy01MaxCount = 20;
    private int currEnemy01Index = 0;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Enemy01MaxCount; ++i)
        {
            Enemy01_Ctrl e01 = Instantiate<Enemy01_Ctrl>(prefab_Enemy01);
            e01.gameObject.SetActive(false);
            Enemy01Pool.Add(e01);
        }
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //Instantiate(spawnEnemy, transform.position, transform.rotation);
            Enemy01Pool[currEnemy01Index].transform.position = gameObject.transform.position;
            Enemy01Pool[currEnemy01Index].gameObject.SetActive(true);

            if (currEnemy01Index >= Enemy01MaxCount - 1)
            {
                currEnemy01Index = 0;
            }
            else
            {
                currEnemy01Index++;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
