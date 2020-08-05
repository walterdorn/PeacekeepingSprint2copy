using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNMODialoguePostVillage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("PostVillage");
    }
}
