using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1Collider : MonoBehaviour
{
    public GameObject woodgatherer;
    // if you collide with the circle the corresponding circle gives you specific dialogue associated with the character
    void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission1Start");
    }
}
