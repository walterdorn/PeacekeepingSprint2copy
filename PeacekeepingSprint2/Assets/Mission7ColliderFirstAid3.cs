using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission7ColliderFirstAid3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission7Start");

    }
}
