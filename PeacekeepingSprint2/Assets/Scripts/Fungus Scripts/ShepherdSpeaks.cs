using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepherdSpeaks : MonoBehaviour
{

    //if the player character enters the dialogue circle, start fungus dialogue with shepherd
    private void OnTriggerEnter(Collider other)
    {

        Fungus.Flowchart.BroadcastFungusMessage("ShepherdSpeaks");
    }

}
