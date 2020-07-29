using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerMovement : MonoBehaviour
{
    public GameObject thirdPersonController;

    public GameObject freeLookCamera;

    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPersonCharacterScript;

    // public ThirdPersonCharacter thirdPersonCharacter;
    // Start is called before the first frame update
    void Start()
    {
        // get reference to interaction script
        
        // get reference to the third person character controller in order to change the move speed multiplier variable.
        thirdPersonCharacterScript = thirdPersonController.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();

    }


    void StopMovement()
    {
        // lowers the speed multiplier on the character stopping their movement
        thirdPersonCharacterScript.m_MoveSpeedMultiplier = 0f;
       // freeLookCamera.SetActive(false);

    }


    void StartMovement()
    {
        // lowers the speed multiplier on the character increasing their movement
        thirdPersonCharacterScript.m_MoveSpeedMultiplier = 1f;
      //  freeLookCamera.SetActive(true);

    }
}
