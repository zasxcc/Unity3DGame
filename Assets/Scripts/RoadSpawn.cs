using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    //오브젝트 풀
    public GameObject prefab_Road;
    private List<GameObject> roadPool = new List<GameObject>();
    //생성 갯수
    private readonly int roadMaxCount = 20;
    private int currRoadIndex = 0;
    
    public float spawnTime = 2.0f;

    private void Awake()
    {
        for (int i = 0; i < roadMaxCount; ++i)
        {
            GameObject r = Instantiate<GameObject>(prefab_Road);
            r.gameObject.SetActive(false);
            roadPool.Add(r);
        }
        StartCoroutine(SpawnRoad());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoad()
    {
        while (true)
        {
            roadPool[currRoadIndex].transform.position = gameObject.transform.position;
            roadPool[currRoadIndex].gameObject.SetActive(true);

            if (currRoadIndex >= roadMaxCount - 1)
            {
                currRoadIndex = 0;
            }
            else
            {
                currRoadIndex++;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
