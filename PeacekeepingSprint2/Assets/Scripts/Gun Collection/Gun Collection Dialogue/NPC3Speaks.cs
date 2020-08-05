using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3Speaks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("NPC3Speaks");
    }
}
