using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOneSpeaks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("NPC1Speaks");
    }
}
