using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float h = 0.0f;
    public float v = 0.0f;
    public float moveSpeed = 10.0f;

    private Transform tr;
    private Animator animator;
    public Transform firePos;

    //오브젝트 풀
    public SwordCtrl prefab_swordBullet;
    private List<SwordCtrl> swordBulletPool = new List<SwordCtrl>();
    //생성 갯수
    private readonly int bulletMaxCount = 20;
    private int currBulletIndex = 0;

    bool animNotify = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
    }


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<bulletMaxCount; ++i)
        {
            SwordCtrl b = Instantiate<SwordCtrl>(prefab_swordBullet);
            b.gameObject.SetActive(false);
            swordBulletPool.Add(b);
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
        tr.Translate(Vector3.right * moveSpeed * h * Time.deltaTime, Space.Self);
        
        if(Input.GetMouseButtonDown(0))
        {
            if (animNotify == true)
            {
                animNotify = false;
                Attack();
            }
        }

        if(animNotify == false)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                animNotify = true;
            }
        }
        
    }

    void Attack()
    {
        int randomNum = 0;
        randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {
            animator.Play("Melee Right Attack 03");
        }
        else if (randomNum == 1)
        {
            animator.Play("Melee Right Attack 01");
        }


        swordBulletPool[currBulletIndex].transform.position = firePos.transform.position;
        swordBulletPool[currBulletIndex].gameObject.SetActive(true);

        if (currBulletIndex >= bulletMaxCount - 1)
        {
            currBulletIndex = 0;
        }
        else
        {
            currBulletIndex++;
        }

    }
}
