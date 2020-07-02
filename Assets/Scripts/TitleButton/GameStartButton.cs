using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    private GameObject target;
    private FadeInOut fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("FadeInOut").GetComponent<FadeInOut>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (target.Equals(gameObject))
            {
                fade.FadeIn(0.7f, () =>
                {
                    SceneManager.LoadScene("GameScene");
                });
            }
        }
    }
    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 


        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.

            target = hit.collider.gameObject;

        }
        return target;
    }


}
