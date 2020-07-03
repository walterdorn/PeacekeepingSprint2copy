using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunCollection : MonoBehaviour
{

    public int gunsCollected;

    public GameObject BurningGrounds;

    public GameObject Logs;

    public int BurnTicket;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CollectGuns();
        BurningGuns();
        LoadMainScene();
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Im Hitting!");
        if (other.tag == "Weapon")
       {
            gunsCollected++;
            Debug.Log("Gun Collected");

            Destroy(other.gameObject);

        }

        if (other.tag == "BurningGrounds" )
        {
            BurningGuns();

        }


    }

    

    public void CollectGuns()
    {
        if(gunsCollected == 6)
        {

            Instantiate(Logs, new Vector3(0, 0, 55), Quaternion.Euler(-90,0,0));

            gunsCollected = 0;

            BurnTicket = 1;
            Debug.Log("All guns collected");
            // head to the burning ceremony
        }

    }


    public void BurningGuns()
    {

        if (Input.GetKey(KeyCode.E))
        {
            if(BurnTicket == 1)
            {
                Instantiate(BurningGrounds, new Vector3(-12f, -1.27f, 68f), Quaternion.identity);
                BurnTicket = 0;

                GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().RepIncreaseBig();
            }

        }

    }

    public void LoadMainScene()
    {

        if (Input.GetKey(KeyCode.V))
        {

            SceneManager.LoadScene("Main_Scene");
        }
    }

    
}
