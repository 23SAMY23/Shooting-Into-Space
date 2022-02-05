using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelloader : MonoBehaviour
{
     public int sceneIndex;
   
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
      
            loadlevel(sceneIndex);
        
        
        
    }

    // Update is called once per frame
 
    public void loadlevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        yield return new WaitForSeconds(35);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
       // Loadingscreen.SetActive(true);
        while (!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
