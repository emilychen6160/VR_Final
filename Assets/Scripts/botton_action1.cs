using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botton_action1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject watergun1;
    public GameObject sword1;
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
        watergun1.SetActive(false);
        sword1.SetActive(true);
    }
}
