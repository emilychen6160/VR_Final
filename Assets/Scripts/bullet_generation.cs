using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_generation : MonoBehaviour
{
    public GameObject generation;
    public GameObject gun;

    bool m_TriggerDown;

    // Start is called before the first frame update

    void Start()
    {
        if (m_TriggerDown)
        {
            Debug.Log("bullet!");
            Instantiate(generation, gun.transform.position + new Vector3(0, 0.102f, 0.2985f), new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(generation, gun.transform.position+new Vector3(0,0.102f,0.2985f), new Quaternion());
    }




}
