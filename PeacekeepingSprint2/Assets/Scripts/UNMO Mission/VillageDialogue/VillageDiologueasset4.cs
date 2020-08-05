using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageDiologueasset4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("VillageLeaderSpeaking");
    }
}
