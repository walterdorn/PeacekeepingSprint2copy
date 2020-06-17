using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiologeEnter : MonoBehaviour

    
{

    public GameObject FlowChart;
    public float enetered;

    private void OnCollisionEnter(Collision hit)
    {
        enetered = 1;
    }
}
