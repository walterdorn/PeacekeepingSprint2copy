using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerDiologe3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Villager3Speaking");
    }
}
