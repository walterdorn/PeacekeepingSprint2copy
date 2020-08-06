using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{

    public AudioClip footStep_Ground1;

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = footStep_Ground1;

    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            GetComponent<AudioSource>().Play();
        }
    }
}
