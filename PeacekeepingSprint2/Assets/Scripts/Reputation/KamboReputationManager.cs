using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamboReputationManager : MonoBehaviour
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

        //grab Kambo Reputation variable
        float KamboRep = GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().KamboRep;

        //if Manana Reputation is in the red (sub 40), instantiate blockades, etc.
        if (KamboRep <= 40 & mapChanging == true)
        {

            Instantiate(object1, position1.transform.position, Quaternion.identity, this.gameObject.transform);
            Instantiate(object2, position2.transform.position, Quaternion.identity, this.gameObject.transform);
            Instantiate(object3, position3.transform.position, Quaternion.identity, this.gameObject.transform);
            Instantiate(object5, position5.transform.position, Quaternion.identity, this.gameObject.transform);

            mapChanging = false;
        }

        //if it's neutral, destroy all instantiated objects
        else if (KamboRep > 40 && KamboRep < 70)
        {

            int children = transform.childCount;

            //for loop to go through instantiate child objects and destroy them
            for (int i = children - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }

            mapChanging = true;
        }

        //if it's positive
        else if (KamboRep > 70 && KamboRep < 100 & mapChanging == true)
        {

            mapChanging = false;
        }
    }
}
