using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawneneies : MonoBehaviour
{
    [Space(15)]
    [Header("enemy")]
    public Transform[] spawnpoint;
    public Transform[] enemies;
    public Transform spawn;
    public Transform ene;
    public GameObject blackhole;
    public bool enemy;
    public bool enemysp;
    [Space(15)]
    [Header("darkhourse")]
    public GameObject fLAREGUN;
    public GameObject DARKHOURSE;
    public bool flare;
    public GameObject friendzone;
    public GameObject[] Enemylist;
    public bool enemydie;
    [Space(15)]
    [Header("Genral")]
    public int currenthighscore;
    public AudioSource telport;
    public int endless;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endless = PlayerPrefs.GetInt("endless");
        currenthighscore = PlayerPrefs.GetInt("currenthighscore");
        if (currenthighscore >= 100 && flare == false && endless == 1 )
        {
            enemy = true;
            fLAREGUN.SetActive(true);
            flare = true;
        }
        if(enemy == false && enemysp == false)
        {
            spawn = spawnpoint[Random.Range(0, spawnpoint.Length)];
            ene = enemies[Random.Range(0, enemies.Length)];
            telport.Play();
            Instantiate(blackhole, spawn.position, spawn.rotation);
            Instantiate(ene, spawn.position, spawn.rotation);
            enemysp = true;
            StartCoroutine(sapwnagain());
        }
        if(enemydie == true)
        {
            friendzone.SetActive(true);
            StartCoroutine(darkspawm());
            StartCoroutine(enemydi());
            StartCoroutine(win());
        }
    }
    private IEnumerator sapwnagain()
    {
        
     yield return new WaitForSeconds(5f);
        enemysp = false;
    }
    private IEnumerator darkspawm()
    {

        yield return new WaitForSeconds(3f);
        DARKHOURSE.SetActive(true);
    }
    private IEnumerator enemydi()
    {

        yield return new WaitForSeconds(3f);
        Enemylist = (GameObject.FindGameObjectsWithTag("Enemy"));
        for (int i = 0; i < Enemylist.Length; i++)
        {

            Enemylist[i].GetComponent<SVTargetDemo>().deaths = true;


        }
    }
    private IEnumerator win()
    {

        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("youwin");
    }

}
