using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamboGateKeeper1Speaks : MonoBehaviour
{

    //if the player character enters the dialogue circle, start fungus dialogue with kambo gatekeeper 1
    private void OnTriggerEnter(Collider other)
    {

        Fungus.Flowchart.BroadcastFungusMessage("KamboGateKeeper1Speaks");
    }
}
