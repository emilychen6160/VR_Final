using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class Switch : MonoBehaviour
    {
        // Start is called before the first frame update
        ActionBaseSwitchProvider mySwitchProvider;
        void Start()
        {
            mySwitchProvider = GetComponent<ActionBaseSwitchProvider>();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(mySwitchProvider.ReadInput());
        }
    }
}
