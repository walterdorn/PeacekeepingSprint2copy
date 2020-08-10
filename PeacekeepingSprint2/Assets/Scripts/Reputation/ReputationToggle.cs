using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationToggle : MonoBehaviour
{

    //reference canvas group on reputation bar
    public CanvasGroup group;

    //bool to toggle visibility
    bool isOn = true;

    // Update is called once per frame
    void Update()
    {
        
        //make canvas group transparent
        if (Input.GetKeyDown(KeyCode.Y) && isOn == true)

        {

            group.alpha = 0;
            isOn = !isOn;
        }

        //make canvas group visible
        else if (Input.GetKeyDown(KeyCode.Y) && isOn == false)
        {

            group.alpha = 1;
            isOn = !isOn;
        }
    }
}
