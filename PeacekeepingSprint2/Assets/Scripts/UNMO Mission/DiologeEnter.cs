using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DiologeEnter : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
         Fungus.Flowchart.BroadcastFungusMessage("Post");
    }

}
