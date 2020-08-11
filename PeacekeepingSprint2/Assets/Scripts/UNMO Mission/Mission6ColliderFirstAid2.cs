﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission6ColliderFirstAid2 : MonoBehaviour
{
    // if you collide with the circle the corresponding circle gives you specific dialogue associated with the character
    private void OnTriggerEnter(Collider other)
    {
        Fungus.Flowchart.BroadcastFungusMessage("Mission6Start");
    }
}
