using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    // this script is on Player

    // the UI TEXT
    public Text InteractText;

    public bool inTower = false;

    public GameObject guardTowerCamera;
    public GameObject binocCamera;
    public GameObject freeLookCamera;
    public GameObject thirdPersonController;

    // mission zone for first aid mission
    public GameObject FirstAidMissionZone;

    // reference to image to put tourniquet into inventory
    public Image tourniquetUIImage;

    // reference to script so can activate the final dialogue for the first aid mission
    public SwitchBetweenFungusDialogue switchBetweenFungusDialogue;

    public Binoculars binocularsScript;

    public void Start()
    {
        //switchBetweenFungusDialogue = GetComponent<SwitchBetweenFungusDialogue>();
        guardTowerCamera.SetActive(false);

        // turn off the UI when game starts
        InteractText.enabled = false;
        tourniquetUIImage.enabled = false;
       
    }

    private void OnTriggerStay(Collider other)
    {
        // can use Input.GetAxis and Input.GetButton (or Input.GetKeyDown)
        if (other.tag == "FirstAidKit" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pick up tourniquet");
            // turn on tourniquet image in UI
            tourniquetUIImage.enabled = true;            

            // this turns off the first mission zone in the first aid mission
            FirstAidMissionZone.SetActive(false);

            // Destroy first aid kit
            Destroy(other.gameObject);

        }

        if (other.tag == "Casualty" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Use tourniquet");

           // switchBetweenFungusDialogue.TurnOnFinalCasualtyDialogue();
            switchBetweenFungusDialogue.GetComponent<SwitchBetweenFungusDialogue>().TurnOnFinalCasualtyDialogue();

            tourniquetUIImage.enabled = false;

        }

        //if (other.tag == "Radio" && Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("Used Radio");
        //    spokeOnRadio = true;

        //}

        if (other.tag == "GuardTower")
        {
            // Show UI E to interact
            Debug.Log("Interact with Guard Tower");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E on Guard Tower");
                inTower = true;
                // set active on guard tower camera
                guardTowerCamera.SetActive(true);
                // set false on binocular, free look camera rig, third person controller
                binocCamera.SetActive(false);
                freeLookCamera.SetActive(false);
                thirdPersonController.SetActive(false);

            }
        }

        if (other.tag == "GuardTowerTop")
        {
            // Show UI E to interact
            // Debug.Log("Get down from Guard Tower");

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Pressed E on GuardTowerTop");

                inTower = false;

                // set active on guard tower camera
                guardTowerCamera.SetActive(false);
                // set false on binocular, free look camera rig, third person controller
                binocCamera.SetActive(true);
                freeLookCamera.SetActive(true);
                thirdPersonController.SetActive(true);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        InteractText.enabled = true;

    }

    private void OnTriggerExit(Collider other)
    {

        InteractText.enabled = false;

    }
}