using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManancaReputationImpact : MonoBehaviour
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

    bool mapChanging = true;   

    void Update()
    {

        float ManancaRep = GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().ManancaRep;

        if (ManancaRep <= 40 & mapChanging == true)
        {

            Instantiate(object6, position6.transform.position, Quaternion.identity, this.gameObject.transform);

            mapChanging = false;
        }

        else if (ManancaRep > 40 && ManancaRep < 70)
        {

            int children = transform.childCount;

            for (int i = children - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }

            mapChanging = true;
        }

        else if (ManancaRep > 70 && ManancaRep < 100 & mapChanging == true)
        {

            mapChanging = false;
        }
    }
}
