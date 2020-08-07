using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenFungusDialogue : MonoBehaviour
{
    // this script is on Car Crash First Aid

    public Interaction interaction;

    public GameObject CarCrashCircle1;
    public GameObject CarCrashCircle2;
    public GameObject CarCrashCircle3;

    public GameObject firstAidKitCircle;

    public GameObject casualtiesCarCrashCircle;

    // to destory casualty and crashed car game objects after quest complete
    public GameObject casualty1;
    public GameObject casualty2;
    public GameObject carCrash;
    

    // Start is called before the first frame update
    void Start()
    {
        // set Fungus circles so can only read them in order
        CarCrashCircle1.SetActive(true);
        CarCrashCircle2.SetActive(false);
        CarCrashCircle3.SetActive(false);
        firstAidKitCircle.SetActive(false);
        casualtiesCarCrashCircle.SetActive(false);

        // Debug.Log("SwitchBetween script");

    }

    void TurnOnRadioDialogue()
    {
        //Debug.Log("TurnOnRadioDialgoue CarCrashCircle2 active");
        CarCrashCircle1.SetActive(false);
        CarCrashCircle2.SetActive(true);
    }

    void TurnOffRadioDialogue()
    {
        //Debug.Log("TurnOffRadioDialogue CarCrashCircle3 active");
        CarCrashCircle2.SetActive(false);
        firstAidKitCircle.SetActive(true);
    }

    public void TurnOnFinalCasualtyDialogue()
    {
        CarCrashCircle3.SetActive(true);
        casualtiesCarCrashCircle.SetActive(false);
    }

    public void TurnOffFirstAidCircle()
    {
        firstAidKitCircle.SetActive(false);
        casualtiesCarCrashCircle.SetActive(true);

    }

    void TurnOffFinalCasualtyDialogue()
    {
        Destroy(casualty1, 1);
        Destroy(casualty2, 1);
        Destroy(carCrash, 1);
        casualtiesCarCrashCircle.SetActive(false);

        CarCrashCircle3.SetActive(false);

    }
}
