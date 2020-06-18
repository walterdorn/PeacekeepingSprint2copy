using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstAidQuest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("firstAidQuest");

            //Input.GetAxis and Input.GetButton (or Input.GetKeyDown)
            if (Input.GetKey("e"))
            {
                Debug.Log("Got e");

            }
        }
    }

}
