using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot : MonoBehaviour
{
  
    [Space(15)]
    [Header("Enemy")]
    public int power;
    public float imebtwShots;
    public float Starttimebtwshots;
    public GameObject muzzle;
    public GameObject Projectile;
    public GameObject fire;
    public AudioSource fireshot;

    [Space(15)]
    [Header("Movement")]
    public Transform Player;
    public float MoveSpeed = 4;
   public int MaxDist = 20;
    public int MinDist = 15;
    public bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        imebtwShots = Starttimebtwshots;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);



        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            



        }

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            transform.position = this.transform.position;
            shoot  = true;
        }
        if (shoot == true)
        {
            if (imebtwShots <= 0)
            {
                fireshot.Play();
                Instantiate(muzzle, fire.transform.position, Quaternion.identity);
                Instantiate(Projectile, fire.transform.position, Quaternion.identity);
                imebtwShots -= Starttimebtwshots;
                imebtwShots = Starttimebtwshots;
            }
            else
            {

                imebtwShots -= Time.deltaTime;
            }
        }
    }
    
}
