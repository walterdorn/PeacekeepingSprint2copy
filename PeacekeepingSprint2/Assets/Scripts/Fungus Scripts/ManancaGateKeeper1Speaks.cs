using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManancaGateKeeper1Speaks : MonoBehaviour
{

    //if the player character enters the dialogue circle, start fungus dialogue with mananca gatekeeper 1
    private void OnTriggerEnter(Collider other)
    {

        Fungus.Flowchart.BroadcastFungusMessage("ManancaGatekeeper1Speaks");
    }
}
