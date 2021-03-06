﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationImpact : MonoBehaviour
{

    //positions to instantiate at
    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject position4;
    public GameObject position5;
    public GameObject position6;

    //instantiable objects
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;

    void Awake()
    {

        float currentRep = GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().currentRep;

        if (currentRep <= 40)
        {

            Instantiate(object1, position1.transform.position, Quaternion.identity);
            Instantiate(object2, position2.transform.position, Quaternion.identity);
            Instantiate(object3, position3.transform.position, Quaternion.identity);
            Instantiate(object4, position4.transform.position, Quaternion.identity);
            Instantiate(object5, position5.transform.position, Quaternion.identity);
        }

        else if (currentRep > 40 && currentRep < 70)
        {


        }

        else if (currentRep >= 70)
        {

            Instantiate(object6, position6.transform.position, Quaternion.identity);
        }
    }
}
