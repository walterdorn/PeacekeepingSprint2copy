using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1Collider : MonoBehaviour
{
    public GameObject woodgatherer;

    void OnTriggerEnter(Collider other)
    {
        if (woodgatherer.GetComponent<Waypoint>().woodGathered == true)
        {
            Fungus.Flowchart.BroadcastFungusMessage("Firewood Collected!");
        }
        else { Fungus.Flowchart.BroadcastFungusMessage("Mission1Start"); }
}
}
