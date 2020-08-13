using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBetweenFungusDialogue : MonoBehaviour
{
    // this script is on Car Crash First Aid

    // to try and get rid of text that pops up after tourniquet
    public Text InteractText;

    // reference to Interaction script
    public Interaction interaction;

    // references to Fungus dialogue circles
    public GameObject CarCrashCircle1;
    public GameObject CarCrashCircle2;
    public GameObject CarCrashCircle3;
    public GameObject firstAidKitCircle;
    public GameObject casualtiesCarCrashCircle;

    // to destroy casualty and crashed car game objects after quest complete
    public GameObject casualty1;
    public GameObject casualty2;
    public GameObject carCrash;

    // For after Car Crash First Aid quest is done, spawn an APC for CASEVAC (no quest associated)
    public GameObject positionForAPC;
    public GameObject APCGameObject;

    // reference to image to hide tourniquet after mission over
    public Image tourniquetImage;

    // Start is called before the first frame update
    void Start()
    {
        // set Fungus circles so can only read them in order
        CarCrashCircle1.SetActive(true);
        CarCrashCircle2.SetActive(false);
        CarCrashCircle3.SetActive(false);
        firstAidKitCircle.SetActive(false);
        casualtiesCarCrashCircle.SetActive(false);

    }

    // called from Fungus during Car Crash First Aid quest
    void TurnOnRadioDialogue()
    {
        //Debug.Log("TurnOnRadioDialgoue CarCrashCircle2 active");
        CarCrashCircle1.SetActive(false);
        CarCrashCircle2.SetActive(true);
    }

    // called from Fungus during Car Crash First Aid quest
    void TurnOffRadioDialogue()
    {
        //Debug.Log("TurnOffRadioDialogue CarCrashCircle3 active");
        CarCrashCircle2.SetActive(false);
        firstAidKitCircle.SetActive(true);
    }

    // called from Fungus during Car Crash First Aid quest
    public void TurnOnFinalCasualtyDialogue()
    {
        CarCrashCircle3.SetActive(true);
        casualtiesCarCrashCircle.SetActive(false);
    }

    // called from Fungus during Car Crash First Aid quest
    public void TurnOffFirstAidCircle()
    {
        firstAidKitCircle.SetActive(false);
        casualtiesCarCrashCircle.SetActive(true);
    }

    // called from Fungus during Car Crash First Aid quest
    void TurnOffFinalCasualtyDialogue()
    {
        // remove the casualty npcs and the car on fire after quest complete
        Destroy(casualty1, 1);
        Destroy(casualty2, 1);
        Destroy(carCrash, 1);

        casualtiesCarCrashCircle.SetActive(false);
       
        Instantiate(APCGameObject, positionForAPC.transform.position, Quaternion.Euler(0f, 90f, 0f), this.gameObject.transform);

        CarCrashCircle3.SetActive(false);

        // to try and get rid of interaction text if it's still showing
        InteractText.enabled = false;

    }

    public void TurnOffTourniquetImage()
    {
        // turn off casualties
        tourniquetImage.enabled = false;

    }
}
