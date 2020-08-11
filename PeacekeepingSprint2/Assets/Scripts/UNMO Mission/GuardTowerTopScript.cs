using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardTowerTopScript : MonoBehaviour
{
    public Interaction interactionScript;
    public GameObject thirdPersonController;
    public GameObject guardBinocCamera;
    public GameObject freeLookCamera;
    public GameObject guardTowerCamera;

    public GameObject BeginningCircle;
    public GameObject SecondCircle;

    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPersonCharacterScript;

    void Start()
    {
        // get reference to interaction script
        interactionScript = thirdPersonController.GetComponent<Interaction>();
        // get reference to the third person character controller in order to change the move speed multiplier variable.
        thirdPersonCharacterScript = thirdPersonController.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();

        // switch available dialogue circles
        SecondCircle.SetActive(false);
        BeginningCircle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("boolean inTower in LeaveGuardTower script: " + interactionScript.inTower);

        // if hit E while in guard tower
        // turn on third person controller
        if (guardTowerCamera)
        {
            if (interactionScript.inTower == true)
            {

                if (Input.GetKeyDown(KeyCode.F) && interactionScript.inTower == true)
                {

                    //Debug.Log("Pressed E on GuardTowerTop script");

                    // set false on binocular, true on free look camera rig, third person controller
                    guardBinocCamera.SetActive(false);
                    freeLookCamera.SetActive(true);
                    thirdPersonController.SetActive(true);

                    // set active on guard tower camera
                    guardTowerCamera.SetActive(false);

                    // swap which circle is active
                    SecondCircle.SetActive(true);
                    BeginningCircle.SetActive(false);

                    // set the boolean inTower to false in Interaction script
                    interactionScript.inTower = false;

                }

            }

        }

    }

}
