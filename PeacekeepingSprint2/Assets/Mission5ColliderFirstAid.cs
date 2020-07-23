using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission5ColliderFirstAid : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission5Start");
    }

}
