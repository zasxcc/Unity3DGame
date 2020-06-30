using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharacterCtrl : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
