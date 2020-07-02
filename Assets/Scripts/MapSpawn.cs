using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    //오브젝트 풀
    public GameObject prefab_Water;
    private List<GameObject> roadPool = new List<GameObject>();
    //생성 갯수
    private readonly int waterMaxCount = 20;
    private int currWaterIndex = 0;

    //오브젝트 풀
    public GameObject prefab_Desert;
    private List<GameObject> desertPool = new List<GameObject>();
    //생성 갯수
    private readonly int desertMaxCount = 20;
    private int currDesertIndex = 0;

    public float spawnTime = 2.0f;

    private void Awake()
    {
        for (int i = 0; i < waterMaxCount; ++i)
        {
            GameObject r = Instantiate<GameObject>(prefab_Water);
            r.gameObject.SetActive(false);
            roadPool.Add(r);
        }

        for (int i = 0; i < desertMaxCount; ++i)
        {
            GameObject d = Instantiate<GameObject>(prefab_Desert);
            d.gameObject.SetActive(false);
            desertPool.Add(d);
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
        Score sc = GameObject.Find("Score").GetComponent<Score>();
    }

    IEnumerator SpawnRoad()
    {
        while (true)
        {
            Score sc = GameObject.Find("Score").GetComponent<Score>();
            if (sc.GetScore() < 500)
            {
                roadPool[currWaterIndex].transform.position = gameObject.transform.position;
                roadPool[currWaterIndex].gameObject.SetActive(true);

                if (currWaterIndex >= waterMaxCount - 1)
                {
                    currWaterIndex = 0;
                }
                else
                {
                    currWaterIndex++;
                }
            }
            else
            {
                desertPool[currDesertIndex].transform.position = gameObject.transform.position;
                desertPool[currDesertIndex].gameObject.SetActive(true);

                if (currDesertIndex >= desertMaxCount - 1)
                {
                    currDesertIndex = 0;
                }
                else
                {
                    currDesertIndex++;
                }
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
