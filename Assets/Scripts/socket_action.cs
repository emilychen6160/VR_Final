using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socket_action : MonoBehaviour
{
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void socket()
    {
        //Debug.Log("in_test");
        //print("in_test_2");
        coin.SetActive(true);
        //coin.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 10.0f, 0.0f));
        coin.GetComponent<Animator>().SetInteger("state", 1);
    }
}
