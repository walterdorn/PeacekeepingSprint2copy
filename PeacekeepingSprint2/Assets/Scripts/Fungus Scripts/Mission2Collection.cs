using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2Collection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission2Start");
    }
}

