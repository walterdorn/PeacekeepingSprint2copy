using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamboGateKeeper2Speaks : MonoBehaviour
{

    //if the player character enters the dialogue circle, start fungus dialogue with kambo gatekeeper 2
    private void OnTriggerEnter(Collider other)
    {

        Fungus.Flowchart.BroadcastFungusMessage("KamboGateKeeper2Speaks");
    }
}
