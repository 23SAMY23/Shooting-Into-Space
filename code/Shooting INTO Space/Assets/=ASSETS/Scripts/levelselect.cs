using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
    public void Levelselect()
    {
        //to change scene to levelselect
        SceneManager.LoadScene("Loading");
    }
}
