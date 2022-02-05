using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maingamehighscore : MonoBehaviour
{
    public int currenthighscore;
    public int points;
    public int HighScore;
    public int compare = 10;
    // Start is called before the first frame update
    private void Awake()
    {
      PlayerPrefs.SetInt("currenthighscore", 0);
        PlayerPrefs.Save();
    }
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        points = PlayerPrefs.GetInt("point");
        currenthighscore = PlayerPrefs.GetInt("currenthighscore");
        this.gameObject.GetComponent<Text>().text = "HighScore:" + " " + currenthighscore;
        if (currenthighscore == compare)
        {
            compare = compare + 10;
            points = points + 1;
            PlayerPrefs.SetInt("point", points);
            PlayerPrefs.Save();
        }
    }
}
