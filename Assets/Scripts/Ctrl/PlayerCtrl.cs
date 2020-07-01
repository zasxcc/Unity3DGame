using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    public float moveSpeed = 10.0f;
    public int HP = 100;
    public float attackPower = 10.0f;

    public AudioClip attackSound;


    private Transform tr;
    private Animator animator;
    private AudioSource audioSource;
    public Transform firePos;
    

    //공격 오브젝트 풀
    public SwordCtrl prefab_swordBullet;
    private List<SwordCtrl> swordBulletPool = new List<SwordCtrl>();
    //생성 갯수
    private readonly int bulletMaxCount = 20;
    private int currBulletIndex = 0;


    //스킬 오브젝트 풀
    public SkillCtrl prefab_Skill;
    private List<SkillCtrl> skillPool = new List<SkillCtrl>();
    //생성 갯수
    private readonly int skillMaxCount = 5;
    private int currSkillIndex = 0;

    

    public float attackDelay = 30.0f;
    private float attackDelayCount = 0.0f;
    bool attackEnable = true;

    public float skillDelay = 100.0f;
    private float skillDelayCount = 0.0f;
    bool skillEnable = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bulletMaxCount; ++i)
        {
            SwordCtrl b = Instantiate<SwordCtrl>(prefab_swordBullet);
            b.SetDamage(attackPower);
            b.gameObject.SetActive(false);
            swordBulletPool.Add(b);
        }

        for (int i = 0; i<skillMaxCount; ++i)
        {
            SkillCtrl skill = Instantiate<SkillCtrl>(prefab_Skill);
            skill.gameObject.SetActive(false);
            skillPool.Add(skill);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
        tr.Translate(Vector3.right * moveSpeed * h * Time.deltaTime, Space.Self);
        
        //공격
        if(Input.GetMouseButtonDown(0))
        {
            if (attackEnable == true)
            {
                audioSource.PlayOneShot(attackSound);
                Attack();
                attackEnable = false;
            }
        }

        //스킬
        if(Input.GetKey(KeyCode.Z))
        {
            if(skillEnable == true)
            {
                Skill();
                skillEnable = false;
            }
        }

        //공격 딜레이
        if(attackEnable == false)
        {
            attackDelayCount++;
            if(attackDelayCount >= attackDelay)
            {
                attackEnable = true;
                attackDelayCount = 0;
            }
        }

        //스킬 딜레이
        if(skillEnable == false)
        {
            skillDelayCount++;
            if(skillDelayCount >= skillDelay)
            {
                skillEnable = true;
                skillDelayCount = 0;
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

    void Skill()
    {
        skillPool[currSkillIndex].transform.position = firePos.transform.position;
        skillPool[currSkillIndex].gameObject.SetActive(true);


        if (currSkillIndex >= skillMaxCount - 1)
        {
            currSkillIndex = 0;
        }
        else
        {
            currSkillIndex++;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ENEMY")
        {
            HP -= 10;
            animator.Play("Take Damage");
            if (HP <= 0)
            {
                SceneManager.LoadScene("HighScoreScene");
            }
        }

        else if(collision.tag == "POWERITEM")
        {
            attackPower += 10.0f;
            for(int i = 0; i<bulletMaxCount; ++i)
            {
                swordBulletPool[i].SetDamage(attackPower);
            }
        }
        else if(collision.tag == "ATTACKSPEEDITEM")
        {
            attackDelay = attackDelay * 0.9f;
        }
     
    }

}
