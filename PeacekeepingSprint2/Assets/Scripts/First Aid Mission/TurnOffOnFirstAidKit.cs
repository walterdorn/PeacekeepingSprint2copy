using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOnFirstAidKit : MonoBehaviour
{

    public GameObject FirstAidKit;
    // Start is called before the first frame update
    void Start()
    {


        FirstAidKit.SetActive(false);
    }


    void TurnMedKitOff()
    {

        FirstAidKit.SetActive(true);

    }
}
