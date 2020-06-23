using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission4Collider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission4Start");
    }
}
