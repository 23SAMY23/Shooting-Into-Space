using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointsadd : MonoBehaviour
{
    public int points;
    public int HighScore;
    public int compare = 10;
    public Text high;
    // Start is called before the first frame update
    void Start()
    {
      
        // points = 3000;


    }

    // Update is called once per frame
    void Update()
    {
        HighScore = PlayerPrefs.GetInt("highscore");
        points = PlayerPrefs.GetInt("point");
        high.GetComponent<Text>().text = "HighScore:" + "   " + HighScore;
        this.GetComponent<Text>().text = "Points:" + "   " + points;
        this.GetComponent<Text>().text = "Points:" + "   " + points;
    }
}
