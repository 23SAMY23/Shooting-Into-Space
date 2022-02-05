using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Transform Player;
    public Vector3 traget;
    public GameObject dust;
    public GameObject blood;
    public float damage = 10f;
    public float currentlfe;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("body").transform;
        currentlfe = Player.gameObject.GetComponent<health>().life;
        traget = new Vector3(Player.position.x, Player.position.y, Player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, traget, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, Player.postion, speed * Time.deltaTime);
        if(transform.position.x  == traget.x && transform.position.y == traget.y && transform.position.z == traget.z )
        {
            Instantiate(dust, transform.position, transform.rotation);
            StartCoroutine(WaitAndPrint(0.2f));
        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("body"))
            {
            currentlfe = currentlfe - damage;
            PlayerPrefs.SetFloat("currentlife", currentlfe);
            PlayerPrefs.Save();
            Player.GetComponent<health>().hit.Play();
           // Player.gameObject.GetComponent<health>().life = currentlfe;
            Instantiate(blood, transform.position, transform.rotation);
            dest();
        }
        }
    
    void dest()
    {
        
        Destroy(gameObject);
    }
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dest();
    }
}
