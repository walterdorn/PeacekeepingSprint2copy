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
    public bool ranCoroutine3 = false;
    public bool ranCoroutine4 = false;
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

    //private void Update()
    //{
    //  Debug.Log("ranCoroutine: " + ranCoroutine + ", ranCoroutine2: "   + ranCoroutine2+   ", ranCoroutine3: "  + ranCoroutine3 + ", ranCoroutine4: " + ranCoroutine4);
    //}

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

            // make the player wait for .5 second before being able to hit E again
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
                //Debug.Log("GuardTower GetKeyDown in Interaction");

                // if hit E, get into tower / swap cameras
                inTower = true;

                // set active on current guard tower camera
                guardTowerCamera.SetActive(true);
                guardTowerCamera2.SetActive(false);

                TurnOffCamerasForTowers();
                StartCoroutine(WaitCoroutine3());

            }
        }

        if (other.tag == "GuardTower2" )
        {
            //Debug.Log("other.tag == GuardTower2 in Interaction");

            if (Input.GetKeyDown(KeyCode.E) )
            {
                //Debug.Log("GuardTower2 GetKeyDown in Interaction");
                inTower = true;

                // set active on current guard tower camera
                guardTowerCamera2.SetActive(true);              
                guardTowerCamera.SetActive(false);

                TurnOffCamerasForTowers();

                StartCoroutine(WaitCoroutine4());

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // show E to interact only when colliding with objects with the following tags
        if (other.tag == "Weapon" || other.tag == "FirstAidKit" || other.tag == "GuardTower" || other.tag == "GuardTower2" || other.tag == "Casualty")
        {
            //Debug.Log("OnTriggerEnter tags Interaction script");
            InteractText.enabled = true;
            InteractText2.enabled = false;
        }

        if (inTower)
        {
            //Debug.Log("inTower: " + inTower);

            // Hide E, show F to interact
            InteractText.enabled = false;
            InteractText2.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // turn off E to interact text when player stops colliding
        InteractText.enabled = false;
        InteractText2.enabled = false;
        colliding = false;

    }

    void TurnOffCamerasForTowers()
    {
        // set false on binocular, free look camera rig, third person controller
        binocCamera.SetActive(false);
        freeLookCamera.SetActive(false);
        //thirdPersonController.SetActive(false);

        // keep Player active but turn off movement while in tower
        changePlayerMovementScript.GetComponent<ChangePlayerMovement>().StopMovement();

    }

    // trying to make it possible to hit E to interact for the first aid kit so they don't all activate at the same time
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

    IEnumerator WaitCoroutine3()
    {
        // for GuardTowerTop script
        yield return new WaitForSeconds(.05f);
        Debug.Log("WaitCoroutine3");
        ranCoroutine3 = true;
    }

    IEnumerator WaitCoroutine4()
    {
        // for GuardTowerTop script
        yield return new WaitForSeconds(.05f);
        Debug.Log("WaitCoroutine4");
        ranCoroutine4 = true;
    }
}