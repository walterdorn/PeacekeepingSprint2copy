using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollection : MonoBehaviour
{
    public GameObject woodOne;
    public GameObject woodTwo;
    public GameObject woodThree;
    public GameObject woodFour;
    public GameObject woodPile;
    public GameObject peacekeepers;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(peacekeepers.GetComponent<Waypoint>().woodGathered == true)
        {
            woodOne.SetActive(true);
            woodTwo.SetActive(true);
            woodThree.SetActive(true);
            woodFour.SetActive(true);
            woodPile.SetActive(false);
        }
    }
}
