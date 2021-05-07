using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;    // 記得加這行

public class bullet_velocity : MonoBehaviour
{
    GameObject ScoreText; //prefab
    GameObject gun;
    GameObject sight;
    public GameObject sum;
    private GameObject score_caculate;

    public int a ;

    // Start is called before the first frame update
    void Start()
    {
        //ScoreText = GameObject.Find("bullet_score");
        gun = GameObject.Find("sight (1)");
        sight = GameObject.Find("sight");
        score_caculate = GameObject.Find("score_caculate");
    }

    private void Awake()
    {
        StartCoroutine(SelfDestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        /*
        if (Input.GetButton("N"))
        {
            Debug.Log("N is presssed");
        }
        */
        if (collision.gameObject.tag == "10")
        {
            print("10");
            a += 10;
            GetComponent<Rigidbody>().isKinematic = true;
            score_caculate.GetComponent<score_sum>().score += 10;
            score_caculate.GetComponent<score_sum>().add_condition = true;
            //namespace TNPro
            //ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = a.ToString();
        }
        if (collision.gameObject.tag == "15")
        {
            print("15");
            a += 15;
            GetComponent<Rigidbody>().isKinematic = true;
            score_caculate.GetComponent<score_sum>().score += 15;
            score_caculate.GetComponent<score_sum>().add_condition = true;
        }
        if (collision.gameObject.tag == "20")
        {
            print("20");
            a += 20;
            GetComponent<Rigidbody>().isKinematic = true;
            score_caculate.GetComponent<score_sum>().score += 20;
            score_caculate.GetComponent<score_sum>().add_condition = true;
        }
        if (collision.gameObject.tag == "25")
        {
            print("25");
            a += 25;
            GetComponent<Rigidbody>().isKinematic = true;
            score_caculate.GetComponent<score_sum>().score += 25;
            score_caculate.GetComponent<score_sum>().add_condition = true;
        }
        if (collision.gameObject.tag == "50")
        {
            print("50");
            a += 50;
            GetComponent<Rigidbody>().isKinematic = true;
            score_caculate.GetComponent<score_sum>().score += 50;
            score_caculate.GetComponent<score_sum>().add_condition = true;
        }
        //else 
        //print("missed");
        //print("trigger");
        //Destroy(gameObject); //這段的用法是當發生碰撞後摧毀對方物件
        
        StopAllCoroutines();

        //Debug.Log("score seperation");
        //ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = a.ToString();


    }

    IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
    //print("trigger");
}
