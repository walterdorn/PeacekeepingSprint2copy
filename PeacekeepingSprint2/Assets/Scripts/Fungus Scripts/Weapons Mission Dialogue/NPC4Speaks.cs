using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4Speaks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("NPC4Speaks");
    }
}
