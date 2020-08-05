using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageDiologue1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Villager1Speaking");
    }
}
