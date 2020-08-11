using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bomb")
        {

           // GameObject.SendMessage(movementSpeed = 0);

            //myObject.GetComponent<Waypoint>().MyFunction();
        }
    }
}
