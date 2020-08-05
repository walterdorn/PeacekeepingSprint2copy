using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission6ColliderFirstAid2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission6Start");
    }
}
