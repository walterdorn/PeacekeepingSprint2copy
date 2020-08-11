using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    //reference explosion effect
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        
        //if the player collides with the bomb, then instantiate the explosion effect at that position
        if (other.tag == "Player")
        {

            Instantiate(explosion, transform.position, Quaternion.identity);

            //currently set to destroy only the bomb, player cannot be killed
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
