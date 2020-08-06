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


    public GameObject BigVillageCircle6;
    public GameObject BigVillageCircle1;
    public GameObject BigVillageCircle2;
    public GameObject BigVillageCircle3;
    public GameObject BigVillageCircle4;
    public GameObject BigVillageCircle5;


    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Weapon4;
    public GameObject Weapon5;
    public GameObject Weapon6;

    public GameObject WeaponMissionStart;

    // Start is called before the first frame update
    void Start()
    {


        BigVillageCircle1.SetActive(false);
        BigVillageCircle2.SetActive(false);
        BigVillageCircle3.SetActive(false);
        BigVillageCircle4.SetActive(false);
        BigVillageCircle5.SetActive(false);
        BigVillageCircle6.SetActive(false);

        Weapon1.SetActive(false);
        Weapon2.SetActive(false);
        Weapon3.SetActive(false);
        Weapon4.SetActive(false);
        Weapon5.SetActive(false);
        Weapon6.SetActive(false);
     


}

// Update is called once per frame
void Update()
    {
        CollectGuns();
        BurningGuns();
        
    }

    void OnTriggerStay(Collider other)
    {

       // Debug.Log("Im Hitting!");
        if (Input.GetKey(KeyCode.E) && other.tag == "Weapon")
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

            Instantiate(Logs, new Vector3(-27, 0, 80), Quaternion.Euler(-90,0,0));

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
                Instantiate(BurningGrounds, new Vector3(-39.1f, -1.0f, 93.11f), Quaternion.identity);
                BurnTicket = 0;

                GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().RepIncreaseBig();
            }

        }

    }

    
    


    void TurnOnVillageWeaponDialogue()
    {
        BigVillageCircle1.SetActive(true);
        BigVillageCircle2.SetActive(true);
        BigVillageCircle3.SetActive(true);
        BigVillageCircle4.SetActive(true);
        BigVillageCircle5.SetActive(true);
        BigVillageCircle6.SetActive(true);


        Weapon1.SetActive(true);
        Weapon2.SetActive(true);
        Weapon3.SetActive(true);
        Weapon4.SetActive(true);
        Weapon5.SetActive(true);
        Weapon6.SetActive(true);

    }

    void TurnWeaponDialogue1Off()
    {
        BigVillageCircle1.SetActive(false);



    }

    void TurnWeaponDialogue2Off()
    {

        BigVillageCircle2.SetActive(false);

    }

    void TurnWeaponDialogue3Off()
    {

        BigVillageCircle3.SetActive(false);
       

    }

    void TurnWeaponDialogue4Off()
    {
        BigVillageCircle4.SetActive(false);


    }

    void TurnWeaponDialogue5Off()
    {

        BigVillageCircle5.SetActive(false);
    }

    void TurnWeaponDialogue6Off()
    {

        BigVillageCircle6.SetActive(false);
    }

    void TurnOffMainWeaponDialogue()
    {

        WeaponMissionStart.SetActive(false);
        
    }
}
