using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {

            Instantiate(explosion, transform.position, Quaternion.identity);

            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
