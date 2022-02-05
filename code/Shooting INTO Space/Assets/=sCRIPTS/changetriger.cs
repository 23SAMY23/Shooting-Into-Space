using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changetriger : MonoBehaviour
{
    public GameObject eNEMY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            eNEMY = other.gameObject;
          //  eNEMY.gameObject.GetComponent<enemyshoot>().wazpoint = true;
        }
    }
}
