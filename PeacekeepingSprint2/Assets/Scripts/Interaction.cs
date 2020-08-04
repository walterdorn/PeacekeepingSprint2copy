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
    public bool tookTourniquet = false;
    bool ranCoroutine = false;        
    bool ranCoroutine2 = false;
    bool colliding = false;

    public GameObject guardTowerCamera;
    public GameObject binocCamera;
    public GameObject freeLookCamera;
    public GameObject thirdPersonController;

    // mission zone for first aid mission
    public GameObject FirstAidMissionZone;

    // reference to image to put tourniquet into inventory
    public Image tourniquetImage;

    // reference to image to search first aid kit box
    public Image firstAidKitImage;

    // referencce to image to show tourniquet in first aid kit
    public Image tourniquetInKitImage;  

    // reference to script so can activate the final dialogue for the first aid mission
    public SwitchBetweenFungusDialogue switchBetweenFungusDialogue;

    public Binoculars binocularsScript;

    // to stop player from moving while using first aid kit
    public ChangePlayerMovement changePlayerMovementScript;
    
    public void Start()
    {
        // to stop player from moving while using first aid kit
        changePlayerMovementScript = changePlayerMovementScript.GetComponent<ChangePlayerMovement>();

        guardTowerCamera.SetActive(false);

        // turn off the UI when game starts
        InteractText.enabled = false;

        // start all first aid kit UI off
        tourniquetImage.enabled = false;
        firstAidKitImage.enabled = false;
        tourniquetInKitImage.enabled = false;

    }

    private void Update()
    {
        Debug.Log("ranCoroutine: " + ranCoroutine + " ranCoroutine2: " + ranCoroutine2);
        Debug.Log("Collider " + colliding);
    }

    private void OnTriggerStay(Collider other)
    {
        colliding = true;
        // can use Input.GetAxis and Input.GetButton (or Input.GetKeyDown)
        if (other.tag == "FirstAidKit" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key x1 - Pick up tourniquet in Interaction Script");             
            changePlayerMovementScript.GetComponent<ChangePlayerMovement>().StopMovement();

            // turn on first aid kit with tourniquet image in UI
            tourniquetImage.enabled = false;
            firstAidKitImage.enabled = true;
            tourniquetInKitImage.enabled = true;

            // this turns off the first mission zone in the first aid mission
            FirstAidMissionZone.SetActive(false);
            
            // make the player wait for 1 second before being able to hit E again
            StartCoroutine(WaitCoroutine());       
        }

        // turn off 2D image of tourniquet in kit with E key
        if (Input.GetKeyDown(KeyCode.E) && ranCoroutine == true)
        {
            Debug.Log("E key x2 - take tourniquet from kit");
            tourniquetInKitImage.enabled = false;
            tourniquetImage.enabled = true;
            StartCoroutine(WaitCoroutine2());
        }

        // turn off 2D image of kit with E key
        if (Input.GetKeyDown(KeyCode.E) && ranCoroutine2 == true)
        {
            Debug.Log("E key x3 - close kit");
            firstAidKitImage.enabled = false;
           
            switchBetweenFungusDialogue.GetComponent<SwitchBetweenFungusDialogue>().TurnOffFirstAidCircle();
            changePlayerMovementScript.GetComponent<ChangePlayerMovement>().StartMovement();
        }


        if (other.tag == "Casualty" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Use tourniquet");       
            switchBetweenFungusDialogue.GetComponent<SwitchBetweenFungusDialogue>().TurnOnFinalCasualtyDialogue();

            // when use tourniquet, turn off image in inventory
            tourniquetImage.enabled = false;
            firstAidKitImage.enabled = false;

        }

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
        if (other.tag == "Weapon" || other.tag == "FirstAidKit" || other.tag == "GuardTower" || other.tag == "Casualty")
        {
            InteractText.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        InteractText.enabled = false;
        colliding = false;

    }

    IEnumerator WaitCoroutine()
    {
       
        Debug.Log("Started Coroutine in Interaction script : " + Time.time);
        yield return new WaitForSeconds(.2f);
        ranCoroutine = true;
        Debug.Log("Ended Coroutine in Interaction script : " + Time.time);
       
    }


    IEnumerator WaitCoroutine2()
    {
        
        Debug.Log("Started Coroutine 2  in Interaction script : " + Time.time);
        yield return new WaitForSeconds(.2f);
        ranCoroutine2 = true;
        Debug.Log("Ended Coroutine 2  in Interaction script : " + Time.time);
        
    }

}