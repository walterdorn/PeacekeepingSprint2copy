using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepherdSpeaks : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        Fungus.Flowchart.BroadcastFungusMessage("ShepherdSpeaks");
    }

}
