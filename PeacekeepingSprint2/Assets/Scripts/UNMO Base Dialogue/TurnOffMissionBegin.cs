using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMissionBegin : MonoBehaviour
{
    public GameObject BeginningCircle;
    public GameObject SecondCircle;

    //public GameObject SecondUNMOTrigger;
    // Start is called before the first frame update
    void Start()
    {
        BeginningCircle.SetActive(true);
        SecondCircle.SetActive(false);        

        //SecondUNMOTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SecondCircle.SetActive(true);
            BeginningCircle.SetActive(false);

            //SecondUNMOTrigger.SetActive(true);

        }

    }
}
