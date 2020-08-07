using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardTowerTopScript : MonoBehaviour
{
    //references to scripts
    // to start the player moving after being in a tower
    public ChangePlayerMovement changePlayerMovementScript;
    public Interaction interactionScript;
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPersonCharacterScript;

    // references to cameras and character controller
    public GameObject thirdPersonController;
    public GameObject binocCamera;
    public GameObject freeLookCamera;
    public GameObject guardTowerCamera;

    // references to fungus dialogue trigger circles
    public GameObject BeginningCircle;
    public GameObject SecondCircle;

    void Start()
    {
        // get reference to interaction script
        interactionScript = thirdPersonController.GetComponent<Interaction>();
        // get reference to the third person character controller in order to change the move speed multiplier variable.
        thirdPersonCharacterScript = thirdPersonController.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();

        // to start the player moving after being in a tower
        changePlayerMovementScript = changePlayerMovementScript.GetComponent<ChangePlayerMovement>();

        // switch available dialogue circles
        SecondCircle.SetActive(false);
        BeginningCircle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // if hit E while in guard tower turn on third person controller
        if (guardTowerCamera)
        {
            //Debug.Log("guardTowerCamera");

            if (Input.GetKeyDown(KeyCode.E) && interactionScript.inTower == true)
            {

                //Debug.Log("interactionScript.inTower");

                if (interactionScript.ranCoroutine3 == true || interactionScript.ranCoroutine4 == true)
                {

                    //Debug.Log("interactionScript.ranCoroutine3 and 4");

                    // set false on binocular, free look camera rig, third person controller
                    binocCamera.SetActive(false);
                    freeLookCamera.SetActive(true);
                    //thirdPersonController.SetActive(true);
                    changePlayerMovementScript.GetComponent<ChangePlayerMovement>().StartMovement();

                    // set active on guard tower camera
                    guardTowerCamera.SetActive(false);

                    // swap which circle is active
                    SecondCircle.SetActive(true);
                    BeginningCircle.SetActive(false);

                    // to get in and out of tower, set these booleans in Interaction script to false
                    interactionScript.inTower = false;
                    interactionScript.ranCoroutine3 = false;
                    interactionScript.ranCoroutine4 = false;

                }

            }

        }

    }

}
