using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNMODialogue1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("CommanderSpeaks");
    }
}
