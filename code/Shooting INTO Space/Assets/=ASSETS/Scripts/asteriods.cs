using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteriods : MonoBehaviour
{
    public GameObject aster;
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
        if (other.gameObject.tag == "player")
        {
            aster.gameObject.SetActive(true);
        }
    }
}