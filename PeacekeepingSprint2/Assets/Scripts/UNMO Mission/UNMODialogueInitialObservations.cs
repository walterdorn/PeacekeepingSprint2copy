using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNMODialogueInitialObservations : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("FirstReport");
    }
}
