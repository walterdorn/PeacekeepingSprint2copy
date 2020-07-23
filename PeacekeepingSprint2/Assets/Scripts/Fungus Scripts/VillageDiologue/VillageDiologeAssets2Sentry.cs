using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageDiologeAssets2Sentry : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("VillageGuardSpeaking");
    }
}
