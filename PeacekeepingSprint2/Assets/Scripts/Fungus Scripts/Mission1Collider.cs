using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1Collider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission1Start");
    }
}
