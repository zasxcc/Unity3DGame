using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public GameObject ImageOnPanel;
    public Texture[] texture = new Texture[7];
    RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = (RawImage)ImageOnPanel.GetComponent<RawImage>();
        img.texture = (Texture)texture[6];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void SetHPBar(int arrNum)
    {
        img.texture = (Texture)texture[arrNum];
    }
}
