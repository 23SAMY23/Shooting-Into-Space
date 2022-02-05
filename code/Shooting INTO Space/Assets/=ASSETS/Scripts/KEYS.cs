using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEYS : MonoBehaviour
{
    public GameObject key;
    // Start is called before the first frame update
   public void open()
    {
        key.SetActive(true);
    }
    public void close()
    {
        key.SetActive(false);
    }
}
