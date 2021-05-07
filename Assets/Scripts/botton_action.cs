using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botton_action : MonoBehaviour
{
    //public Button yourButton;
    public GameObject watergun;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        watergun.SetActive(true);
        sword.SetActive(false);
    }
}
