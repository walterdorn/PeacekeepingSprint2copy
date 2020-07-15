using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGuardTower : MonoBehaviour
{    
    public Interaction interactionScript;
    public GameObject thirdPersonController;   
    public GameObject binocCamera;
    public GameObject freeLookCamera;
    public Camera guardTowerCamera;

    private void Start()
    {
        interactionScript = thirdPersonController.GetComponent<Interaction>();        
    }

    // Update is called once per frame
    void Update()
    {
        // if hit E while in guard tower
        // turn on third person controller
        if (guardTowerCamera)
        {
            if (interactionScript.inTower == true)
            {
                Debug.Log("check if inTower is true ");
                LeaveTower();
            }
        }
        
    }

    void LeaveTower()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {                             
            Debug.Log("Pressed E on GuardTowerTop");

            
            freeLookCamera.SetActive(true);
            thirdPersonController.SetActive(true);        
            
        }

    }

}
