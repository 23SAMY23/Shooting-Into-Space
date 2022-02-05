using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SVTargetDemo : SVShootable
{
	[Space(15)]
	[Header("Gunname")]
	public bool splash;
	public bool endless;
	public bool load;
	public bool SKIP;
	public bool rose;
	public bool ELETRIC;
	public bool SANDGUN;
	public bool SANDBULLET;
	public GameObject sabull;
	public GameObject sagun;
	public int sain;
	[Space(15)]
	[Header("Enemyname")]

	public bool minion;
	
	public bool darkhourse;
	public bool hEALTH;
	public bool lvl2;
	
	[Space(15)]
	[Header("spawnobject")]
	public GameObject Health;
	public GameObject rosebul;
	public GameObject electricbul;
	public GameObject sandbul;
	public bool rosbul;
	public bool elecbul;
	public bool sanbul;
	public GameObject bomb;
	public GameObject star;
	public GameObject parent;
	[Space(15)]
	[Header("Genral")]
	public AudioSource bom;
	public int levl;
	public int damage = 50;
	public int destroy;
	public int highscore;
	public int currenthighscore;
	public int points;
	public int bullets;
	public int curretrbullet ;
	public float currentlife;
	public bool deaths;
	// Use this for initialization
	void Start()
	{
		highscore = PlayerPrefs.GetInt("highscore");
		
		points = PlayerPrefs.GetInt("point");
		if (rose == true)
		{
			parent = GameObject.FindGameObjectWithTag("Rose");
		}
		if (ELETRIC == true)
		{
			parent = GameObject.FindGameObjectWithTag("Electric");
		}
		if (SANDGUN == true)
		{
			parent = GameObject.FindGameObjectWithTag("Sand");
		}
		//points = 3000;
		sain = PlayerPrefs.GetInt("sandgun");
		if (SANDGUN == true && sain == 1)
		{
			sabull.gameObject.SetActive(true);
			sagun.gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
	{
		currenthighscore = PlayerPrefs.GetInt("currenthighscore");
		if (rose == true || ELETRIC == true || SANDGUN == true || rosebul == true || elecbul == true || sanbul == true) {
			curretrbullet = parent.gameObject.GetComponent<SVRevolver>().maxBullets;
		}
		currentlife=  PlayerPrefs.GetFloat("currentlife");

		if (deaths == true)
		{
			Instantiate(bomb, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			Destroy(this.gameObject);
			bom.Play();
			
		}

	}

	public override void Hit(RaycastHit hit, SVBullet bullet, Vector3 rayDirection)
	{
		base.Hit(hit, bullet, rayDirection);
		float instX = this.transform.position.x;
		float instY = this.transform.position.y;
		float instZ = this.transform.position.z;
		if (splash == true)
		{
			SceneManager.LoadScene("Mainmenau");
		}
		if (endless == true)
		{
			PlayerPrefs.SetInt("endless", 0);
			PlayerPrefs.Save();
			SceneManager.LoadScene("Loading");
		}
		if (load == true)
		{
			PlayerPrefs.SetInt("endless", 1);
			PlayerPrefs.Save();
			SceneManager.LoadScene("Loading");
		}
		if (SKIP== true)
		{
			SceneManager.LoadScene("main game");
		}
		if (minion == true)
		{
			int ran;
			ran = Random.Range(0, 3);
			Debug.Log(ran);
			if (ran == 0)
			{
				Instantiate(Health, new Vector3(instX, instY, instZ), Quaternion.identity);
			}else if (ran == 1)
			{
				Instantiate(rosebul, new Vector3(instX, instY, instZ), Quaternion.identity);
			}
			else if (ran == 2)
			{
				Instantiate(electricbul, new Vector3(instX, instY, instZ), Quaternion.identity);
			}
			else if (ran == 3)
			{
				Instantiate(sabull, new Vector3(instX, instY, instZ), Quaternion.identity);
			}


		}
		if (darkhourse == true)
		{
			GameObject.FindGameObjectWithTag("gamemanager").GetComponent<spawneneies>().enemydie = true;
		}
		if (lvl2 == true)
		{
			damage = damage - 20 ;
			if (damage <= 0)
			{
				Instantiate(bomb, new Vector3(instX, instY, instZ), Quaternion.identity);
				currenthighscore = currenthighscore + 1;
				PlayerPrefs.SetInt("currenthighscore",currenthighscore);
				PlayerPrefs.Save();
				if (currenthighscore > highscore)
				{
					PlayerPrefs.SetInt("highscore", currenthighscore);
				}
					StartCoroutine(death());
			}
		


		}
		if( hEALTH == true)
		{
			if (currentlife < 100)
			{
				currentlife = currentlife + 30;
				PlayerPrefs.SetFloat("currentlife", currentlife);
				PlayerPrefs.Save();
				Instantiate(star, new Vector3(instX, instY, instZ), Quaternion.identity);
				StartCoroutine(death());
			}
		}
		if (rose == true)
		{
			if(points >= 20)
			{

				
				bullets = bullets + curretrbullet;
				PlayerPrefs.SetInt("rosebullet", bullets);
				PlayerPrefs.Save();
				//parent.gameObject.GetComponent<SVRevolver>().maxBullets = bullets;
				points = points - 30;
				PlayerPrefs.SetInt("point", points);
				PlayerPrefs.Save();
			}
		}
		if (ELETRIC == true)
		{
			if (points >= 30)
			{
				bullets = bullets + curretrbullet;
				PlayerPrefs.SetInt("electricbullet", bullets);
				PlayerPrefs.Save();
				//parent.gameObject.GetComponent<SVRevolver>().maxBullets = bullets;
				points = points - 30;
				PlayerPrefs.SetInt("point", points);
				PlayerPrefs.Save();
			}
		}
		if (SANDBULLET == true)
		{
			if (points >= 40)
			{

				Debug.Log("sassa");
				bullets = bullets + curretrbullet;
				PlayerPrefs.SetInt("sandbulet", bullets);
				PlayerPrefs.Save();
				//parent.gameObject.GetComponent<SVRevolver>().maxBullets = bullets;
				points = points - 50;
				PlayerPrefs.SetInt("point", points);
				PlayerPrefs.Save();
			}
		}
		if (SANDGUN == true)
		{
			if (points >= 1000)
			{
				PlayerPrefs.SetInt("sandgun", 1);
				PlayerPrefs.Save();
				
				points = points - 1000;
				PlayerPrefs.SetInt("point", points);
				PlayerPrefs.Save();
				sabull.gameObject.SetActive(true);
				sagun.gameObject.SetActive(false);
			}
		}
		if (rosebul == true)
		{

				bullets = bullets + curretrbullet;
				PlayerPrefs.SetInt("rosebullet", bullets);
				PlayerPrefs.Save();
		}
		if (elecbul == true)
		{

			bullets = bullets + curretrbullet;
			PlayerPrefs.SetInt("electricbullet", bullets);
			PlayerPrefs.Save();
		}
		if (sanbul == true)
		{

			bullets = bullets + curretrbullet;
			PlayerPrefs.SetInt("sandbulet", bullets);
			PlayerPrefs.Save();
		}
	}
	

	private IEnumerator death()
	{

		bom.Play();
		Destroy(this.gameObject);
		
		yield return null;
	}
}
