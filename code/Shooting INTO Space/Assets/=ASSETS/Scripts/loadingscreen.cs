using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingscreen : MonoBehaviour
{
    public int levl;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
    public void Levelload(int levl)
    {
        PlayerPrefs.SetInt("level", levl);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Loading");

    }
    
}
