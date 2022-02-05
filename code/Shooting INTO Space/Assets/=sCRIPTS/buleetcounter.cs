using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buleetcounter : MonoBehaviour
{
    public GameObject parent;
    public int bullet;
    public int mbullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mbullet = parent.gameObject.GetComponent<SVRevolver>().maxBullets;
        bullet = parent.gameObject.GetComponent<SVRevolver>().curBullets;
        this.GetComponent<Text>().text = "Bullet" + " " + bullet + "/" + mbullet;
    }
}
