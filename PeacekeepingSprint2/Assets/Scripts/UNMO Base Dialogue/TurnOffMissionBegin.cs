using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMissionBegin : MonoBehaviour
{

    public GameObject BeginningCircle;
    public GameObject SecondCircle;
    // Start is called before the first frame update
    void Start()
    {
        SecondCircle.SetActive(false);
        BeginningCircle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            SecondCircle.SetActive(true);
            BeginningCircle.SetActive(false);

        }
    }
}
