using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSpawnMananger : MonoBehaviour
{

    //positions to instantiate peace meeting at
    public GameObject position9;

    //instantiable peace meeting
    public GameObject object9;

    //controls when the object is allowed to spawn
    bool mapChanging = true;

    // Update is called once per frame
    void Update()
    {

        //grab Reputation variables
        float KamboRep = GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().KamboRep;
        float ManancaRep = GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().ManancaRep;

        //if Reputation for both villages is above 70, instantiate peace meeting
        if (KamboRep >= 70 & ManancaRep >= 70 && mapChanging == true)
        {

            Instantiate(object9, position9.transform.position, Quaternion.identity, this.gameObject.transform);

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
    }
}
