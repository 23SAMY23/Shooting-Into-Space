using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carcontroller : MonoBehaviour
{
    public GameObject diedui;
    public float speed = 7.0f;
    public float Rocketspeed = 20.0f;
    public Rigidbody rb;
    public Vector3 movement;
    float timeLeft = 2.0f;
    public float timespend = 0.0f;
    public Text playtime;
    public bool jumpp;
    public int jup;
    public Text jumpy;
    public GameObject jumppart;
    public bool boosts;
    public int boo;
    public Text boosty;
    public GameObject bostpart;
    public bool slows;
    public int sow;
    public Text slowly;
    public GameObject slowpart;
    double time;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        jup = PlayerPrefs.GetInt("jump");
        jumpy.GetComponent<Text>().text = jup.ToString();
        boo= PlayerPrefs.GetInt("boost");
        boosty.GetComponent<Text>().text = boo.ToString();
        sow = PlayerPrefs.GetInt("slowdown");
        slowly.GetComponent<Text>().text = sow.ToString();
        timespend = PlayerPrefs.GetFloat("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 5.0f);
        //input controls
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 1 * Rocketspeed * Time.deltaTime);

        timespend += Time.deltaTime;
        time = System.Math.Round(timespend, 2);
        PlayerPrefs.SetFloat("highscore", timespend);
        PlayerPrefs.Save();
        playtime.GetComponent<Text>().text = "PlayTime"+ time.ToString();


        if (Input.GetKeyDown(KeyCode.X))
        {
            jumpp = true;
           
            
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            boosts = true;
            
           
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            slows = true;
            
            
        }

        if (jumpp == true && jup > 0)
        {
            jumppart.SetActive(true);
            speed = 10f;
            timeLeft -= Time.deltaTime;
          
            if (timeLeft < 0)
            {
                speed = 7f;
                jumpp = false;
                jup = jup - 1;
                jumpy.GetComponent<Text>().text = jup.ToString();
                jumppart.SetActive(false);
                PlayerPrefs.SetInt("jump", jup);
                PlayerPrefs.Save();
                timeLeft = 2.0f;
            }
        }


        if (jup <= 0)
        {
            jup = 0;
            jumpy.GetComponent<Text>().text = jup.ToString();
        }

        if (boosts == true && boo > 0)
        {
            bostpart.SetActive(true);
            Rocketspeed = 60f;
            timeLeft -= Time.deltaTime;
            
            if (timeLeft < 0)
            {
                Rocketspeed = 40f;
                boosts = false;
                boo = boo - 1;
                boosty.GetComponent<Text>().text = boo.ToString();
                bostpart.SetActive(false);
                PlayerPrefs.SetInt("boost", boo);
                PlayerPrefs.Save();
                timeLeft = 2.0f;
            }
        }
        if (boo <= 0)
        {
            boo= 0;
            boosty.GetComponent<Text>().text = boo.ToString();
        }

        if (slows == true && sow > 0)
        {
            slowpart.SetActive(true);
            Rocketspeed = 20f;
            timeLeft -= Time.deltaTime;
            
            if (timeLeft < 0)
            {
                
                Rocketspeed = 40f;
                slows = false;
                sow = sow - 1;
                slowly.GetComponent<Text>().text = sow.ToString();
                slowpart.SetActive(false);
                PlayerPrefs.SetInt("slowdown", sow);
                PlayerPrefs.Save();
                timeLeft = 2.0f;
            }
        }
        if (sow <= 0)
        {
            sow = 0;
            slowly.GetComponent<Text>().text = sow.ToString();
        }
    }
    void FixedUpdate()
    {
        moveCharacter(movement);

    }
    void moveCharacter(Vector3 direction)
    {
        //to addforce in the movement of the rocket
        rb.AddForce(direction * speed);
        //to move the rocket to diferent position 
        rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dead")
        {
            //to change scene to levelfailed
            SceneManager.LoadScene("Levelfailed");

        }
        
    }
        private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "boost")
        {
            boo = boo + 1;
            boosty.GetComponent<Text>().text = boo.ToString();
            PlayerPrefs.SetInt("boost", boo);
            PlayerPrefs.Save();
            
            Destroy(GameObject.FindGameObjectWithTag("boost"));

        }
        if (other.gameObject.tag == "jump")
        {
            
            jup = jup + 1;
            jumpy.GetComponent<Text>().text = jup.ToString();
            PlayerPrefs.SetInt("jump", jup);
            PlayerPrefs.Save();
            
            Destroy(GameObject.FindGameObjectWithTag("jump"));
        }
       
        if (other.gameObject.tag == "slowdown")
        {
            sow = sow + 1;
            slowly.GetComponent<Text>().text = sow.ToString();
            PlayerPrefs.SetInt("slowdown", sow);
            PlayerPrefs.Save();
            
            Destroy(GameObject.FindGameObjectWithTag("slowdown"));
        }
    }
}
