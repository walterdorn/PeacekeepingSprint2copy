using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    //reference player transform for position
    public Transform player;


     void LateUpdate()
    {
        // follow the player from a variable distance above them
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
