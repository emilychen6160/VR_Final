using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_sum : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public bool add_condition;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        add_condition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(add_condition == true)
        {
            //scoreText.GetComponent<Text>().text = ("Score: ");
            scoreText.GetComponent<Text>().text = "Score:" + (score.ToString());
            add_condition = false;
        }

    }
}
