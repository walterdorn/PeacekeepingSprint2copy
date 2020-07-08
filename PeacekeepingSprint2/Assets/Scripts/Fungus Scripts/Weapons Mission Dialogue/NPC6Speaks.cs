using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC6Speaks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("NPC6Speaks");
    }
}
