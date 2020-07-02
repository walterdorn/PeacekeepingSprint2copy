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
        // can use Input.GetAxis and Input.GetButton (or Input.GetKeyDown)
        if (other.tag == "FirstAidKit" && Input.GetKeyDown(KeyCode.E))
        {
            
            Debug.Log("Pick up tourniquet");
            // CollectTourniquet();

            // Destroy first aid kit
            Destroy(other.gameObject);
        }

    }

    //void CollectTourniquet()
    //{
    //    Debug.Log("Pick up tourniquet, show image.");
    //    
    //}

}
