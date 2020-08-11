using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    // this script is on Player

    public AudioClip firstAidKitSound;

    // the UI TEXT
    public Text InteractText;
    public Text InteractText2;

    public bool inTower = false;
    public bool tookTourniquet = false;
    bool ranCoroutine = false;
    bool ranCoroutine2 = false;
    bool colliding = false;

    public GameObject guardTowerCamera;
    public GameObject guardTowerCamera2;
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
        guardTowerCamera2.SetActive(false);

        // turn off the UI when game starts
        InteractText.enabled = false;
        InteractText2.enabled = false;

        // start all first aid kit UI off
        tourniquetImage.enabled = false;
        firstAidKitImage.enabled = false;
        tourniquetInKitImage.enabled = false;

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = firstAidKitSound;

    }

    private void OnTriggerStay(Collider other)
    {
        colliding = true;
        // can use Input.GetAxis and Input.GetButton (or Input.GetKeyDown)
        if (other.tag == "FirstAidKit" && Input.GetKeyDown(KeyCode.E))
        {
            // play the open first aid kit sound
            GetComponent<AudioSource>().Play();

            //Debug.Log("E key x1 - Pick up tourniquet in Interaction Script");             
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
            //Debug.Log("E key x2 - take tourniquet from kit");
            tourniquetInKitImage.enabled = false;
            tourniquetImage.enabled = true;
            StartCoroutine(WaitCoroutine2());
        }

        // turn off 2D image of kit with E key
        if (Input.GetKeyDown(KeyCode.E) && ranCoroutine2 == true)
        {
            //Debug.Log("E key x3 - close kit");
            firstAidKitImage.enabled = false;

            switchBetweenFungusDialogue.GetComponent<SwitchBetweenFungusDialogue>().TurnOffFirstAidCircle();
            changePlayerMovementScript.GetComponent<ChangePlayerMovement>().StartMovement();
        }


        if (other.tag == "Casualty" && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Use tourniquet");       
            switchBetweenFungusDialogue.GetComponent<SwitchBetweenFungusDialogue>().TurnOnFinalCasualtyDialogue();

            // when use tourniquet, turn off image in inventory
            tourniquetImage.enabled = false;
            firstAidKitImage.enabled = false;

        }

        if (other.tag == "GuardTower")
        {
            //Debug.Log("Interact with Guard Tower");

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Pressed E on Guard Tower");
                inTower = true;
                // set active on guard tower camera
                guardTowerCamera.SetActive(true);

                // set false on binocular, free look camera rig, third person controller
                guardTowerCamera2.SetActive(false);
                binocCamera.SetActive(false);
                freeLookCamera.SetActive(false);
                thirdPersonController.SetActive(false);

                // use Interact text 2
                InteractText.enabled = false;
                InteractText2.enabled = true;
            }
        }

        if (other.tag == "GuardTower2")
        {
            //Debug.Log("Interact with Guard Tower");

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Pressed E on Guard Tower");
                inTower = true;

                // set active on guard tower camera
                guardTowerCamera2.SetActive(true);

                // set false on binocular, free look camera rig, third person controller
                guardTowerCamera.SetActive(false);
                binocCamera.SetActive(false);
                freeLookCamera.SetActive(false);
                thirdPersonController.SetActive(false);

                // use Interact text 2
                InteractText.enabled = false;
                InteractText2.enabled = true;

            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        // show E to interact only when colliding with objects with the following tags
        if (other.tag == "Weapon" || other.tag == "FirstAidKit" || other.tag == "GuardTower" || other.tag == "GuardTower2" || other.tag == "Casualty" || other.tag == "BurningGrounds")
        {
            Debug.Log("OnTriggerEnter tags Interaction script");
            InteractText.enabled = true;
            InteractText2.enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // turn off E to interact text when stop colliding
        InteractText.enabled = false;
        InteractText2.enabled = false;
        colliding = false;

    }

    IEnumerator WaitCoroutine()
    {

        yield return new WaitForSeconds(.05f);
        ranCoroutine = true;

    }


    IEnumerator WaitCoroutine2()
    {

        yield return new WaitForSeconds(.05f);
        ranCoroutine2 = true;

    }

}
