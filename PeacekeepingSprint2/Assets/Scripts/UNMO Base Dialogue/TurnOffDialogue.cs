using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffDialogue : MonoBehaviour
{
    
   
    public GameObject SecondCircle;
    public GameObject VillageCircle1;

    // Start is called before the first frame update
    void Start()
    {
        VillageCircle1.SetActive(false);
        SecondCircle.SetActive(true);

    }

  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Second UNMO Circle")
        {
            if(!SecondCircle.activeSelf)
            {
                VillageCircle1.SetActive(true);
                SecondCircle.SetActive(false);

                Destroy(other.gameObject);

            }

        }


    }
}
