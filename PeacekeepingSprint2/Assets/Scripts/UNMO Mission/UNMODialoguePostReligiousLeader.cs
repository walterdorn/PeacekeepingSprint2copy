using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNMODialoguePostReligiousLeader : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("PostReligiousLeader");
    }
}
