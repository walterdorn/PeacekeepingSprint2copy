using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerDiologe2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Villager2Speaking");
    }
}
