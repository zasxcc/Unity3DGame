using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject spawnEnemy;
    public float spawnTime = 2.0f;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(spawnEnemy, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
