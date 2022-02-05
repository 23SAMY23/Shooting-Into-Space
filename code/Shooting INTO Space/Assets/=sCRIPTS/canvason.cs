using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvason : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Body;
    // Start is called before the first frame update
    void Start()
    {
        Body = GameObject.FindGameObjectWithTag("body");
        canvas = GameObject.FindGameObjectWithTag ("gamecanvas").gameObject;
        canvas.GetComponent<Canvas>().enabled = true;
        Body.GetComponent<health>().life = 100;
        Body.GetComponent<health>().enabled = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
