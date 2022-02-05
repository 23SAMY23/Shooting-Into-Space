using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class health : MonoBehaviour
{
    public Slider heath;
    public float life = 100;
    public GameObject camera;
    public bool dead;
    public AudioSource bom;
    public AudioSource hit;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("currentlife", 100);
        PlayerPrefs.Save();
        heath.value = life;
      
    }

    // Update is called once per frame
    void Update()
    {
        life = PlayerPrefs.GetFloat("currentlife");
        heath.value = life;
       
        if(dead == true)
        {
            
           
            StartCoroutine(liferegain());
        }
        if (life <= 0 && dead == false)
        {
            bom.Play();
            camera.GetComponent<Camera>().enabled = false;
            PlayerPrefs.SetFloat("currentlife", 100);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("currenthighscore", 0);
            PlayerPrefs.Save();
            heath.value = life;
            dead = true;
            StartCoroutine(restar());
        }
    }
    private IEnumerator restar()
    {

        yield return new WaitForSeconds(1f);
        canvas.GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene("Mainmenau");
    }
    private IEnumerator liferegain()
    {

        yield return new WaitForSeconds(0.1f);
        camera.GetComponent<Camera>().enabled = true;
        dead = false;
    }
}
