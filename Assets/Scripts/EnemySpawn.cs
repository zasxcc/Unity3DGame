using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float spawnTime = 2.0f;

    //오브젝트 풀
    public Enemy_Ctrl prefab_Enemy01;
    private List<Enemy_Ctrl> Enemy01Pool = new List<Enemy_Ctrl>();

    public Enemy_Ctrl prefab_Enemy02;
    private List<Enemy_Ctrl> Enemy02Pool = new List<Enemy_Ctrl>();
    //생성 갯수
    private readonly int Enemy01MaxCount = 10;
    private int currEnemy01Index = 0;

    private readonly int Enemy02MaxCount = 10;
    private int currEnemy02Index = 0;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Enemy01MaxCount; ++i)
        {
            Enemy_Ctrl e01 = Instantiate<Enemy_Ctrl>(prefab_Enemy01);
            e01.gameObject.SetActive(false);
            Enemy01Pool.Add(e01);
        }

        for (int i = 0; i < Enemy02MaxCount; ++i)
        {
            Enemy_Ctrl e02 = Instantiate<Enemy_Ctrl>(prefab_Enemy02);
            e02.gameObject.SetActive(false);
            Enemy02Pool.Add(e02);
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
            int num = Random.Range(0, 10);
            if (num < 7)
            {
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
            }
            else
            {
                Enemy02Pool[currEnemy02Index].transform.position = gameObject.transform.position;
                Enemy02Pool[currEnemy02Index].gameObject.SetActive(true);

                if (currEnemy02Index >= Enemy02MaxCount - 1)
                {
                    currEnemy02Index = 0;
                }
                else
                {
                    currEnemy02Index++;
                }
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
