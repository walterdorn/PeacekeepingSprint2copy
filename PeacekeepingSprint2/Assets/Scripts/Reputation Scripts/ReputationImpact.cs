using System.Collections;
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

    //instantiable objects
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;

    void Awake()
    {

        float currentRep = GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().currentRep;

        if (currentRep <= 40)
        {


        }

        else if (currentRep > 40 && currentRep < 70)
        {


        }

        else if (currentRep > 70)
        {


        }
    }
}
