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
        CarCrashCircle3.SetActive(false);
    }
}
