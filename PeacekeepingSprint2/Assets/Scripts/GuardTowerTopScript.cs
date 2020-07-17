using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTowerTopScript : MonoBehaviour
{
    public Interaction interactionScript;
    public GameObject thirdPersonController;
    public GameObject binocCamera;
    public GameObject freeLookCamera;
    public GameObject guardTowerCamera;

    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPersonCharacterScript;

    void Start()
    {
        // get reference to interaction script
        interactionScript = thirdPersonController.GetComponent<Interaction>();
        // get reference to the third person character controller in order to change the move speed multiplier variable.
        thirdPersonCharacterScript = thirdPersonController.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("boolean inTower in LeaveGuardTower script: " + interactionScript.inTower);
        // if hit E while in guard tower
        // turn on third person controller
        if (guardTowerCamera)
        {
            if (interactionScript.inTower == true)
            {
                //Debug.Log("check if inTower is true ");



                if (Input.GetKeyDown(KeyCode.F) && interactionScript.inTower == true)
                {

                    Debug.Log("Pressed E on GuardTowerTop");

                    
                    // set false on binocular, free look camera rig, third person controller
                    binocCamera.SetActive(false);
                    freeLookCamera.SetActive(true);
                    thirdPersonController.SetActive(true);

                    // set active on guard tower camera
                    guardTowerCamera.SetActive(false);

                    if (guardTowerCamera)
                    {

                    }



                   // thirdPersonCharacterScript.m_MoveSpeedMultiplier = 1f;

                    //Debug.Log("thirdPersonCharacterScript.m_MoveSpeedMultiplier in LeaveGuardTower script: " + thirdPersonCharacterScript.m_MoveSpeedMultiplier);

                    //StartCoroutine(WaitForSecondsCoroutine());
                    interactionScript.inTower = false;

                }

            }

        }

    }

    //IEnumerator WaitForSecondsCoroutine()
    //{
    //    //Print the time of when the function is first called.
    //    //Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //    //yield on a new YieldInstruction that waits for 1 seconds.
    //    yield return new WaitForSeconds(1);

    //    //After we have waited 5 seconds print the time again.
    //    Debug.Log("Finished Coroutine at timestamp for LeaveGuardTower: " + Time.time);
    //}


}
