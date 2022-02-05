using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class maxbullet : MonoBehaviour
{
    public GameObject parent;
    public bool rose;
    public bool ELETRIC;
    public bool SANDGUN;
    public int maxbul;
    
    // Start is called before the first frame update
    void Start()
    {
        if (rose == true )
        {
            parent = GameObject.FindGameObjectWithTag("Rose");
        }
        if(ELETRIC == true)
        {
            parent = GameObject.FindGameObjectWithTag("Electric");
        }
        if (SANDGUN == true)
        {
            parent = GameObject.FindGameObjectWithTag("Sand");
        }

    }

    // Update is called once per frame
    void Update()
    {
        maxbul = parent.gameObject.GetComponent<SVRevolver>().maxBullets;
        
        this.gameObject.GetComponent<Text>().text = "Max Bullet:" + " " + maxbul;
    }
}
