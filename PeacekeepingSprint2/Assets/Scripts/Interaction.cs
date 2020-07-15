using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool inTower = false;

    public GameObject guardTowerCamera;
    public GameObject binocCamera;
    public GameObject freeLookCamera;
    public GameObject thirdPersonController;

    public float xPositionGuardTower;
    public float yPositionGuardTower;
    public float zPositionGuardTower;
 
    public Binoculars binocularsScript;

    public void Start()
    {
        guardTowerCamera.SetActive(false);

        xPositionGuardTower = -54;
        yPositionGuardTower = 4;
        zPositionGuardTower = 96.3f;
    }

    private void OnTriggerStay(Collider other)
    {
        // can use Input.GetAxis and Input.GetButton (or Input.GetKeyDown)
        if (other.tag == "FirstAidKit" && Input.GetKeyDown(KeyCode.E))
        {

            Debug.Log("Pick up tourniquet");

            // CollectTourniquet();

            // Destroy first aid kit
            Destroy(other.gameObject);
        }

        if (other.tag == "GuardTower")
        {
            // Show UI E to interact
            Debug.Log("Interact with Guard Tower");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E on Guard Tower");
                inTower = true;
                // set active on guard tower camera
                guardTowerCamera.SetActive(true);
                // set false on binocular, free look camera rig, third person controller
                binocCamera.SetActive(false);
                freeLookCamera.SetActive(false);
                thirdPersonController.SetActive(false);

                // Fade to black 
                //binocularsScript = GetComponent<Binoculars>();

                // turn off third person controller
                //thirdPersonController.SetActive(false);

                // position binocular camera up in guard tower
                //transform.position = new Vector3(xPositionGuardTower, yPositionGuardTower, zPositionGuardTower);

                // fade into binoculars
                // call binoculars script

                // free look? full 360

                // E to go back to bottom of guard tower

                // set 

            }
        }

        if (other.tag == "GuardTowerTop")
        {
            // Show UI E to interact
            Debug.Log("Get down from Guard Tower");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E on GuardTowerTop");

                inTower = false;

                // set active on guard tower camera
                guardTowerCamera.SetActive(false);
                // set false on binocular, free look camera rig, third person controller
                binocCamera.SetActive(true);
                freeLookCamera.SetActive(true);
                thirdPersonController.SetActive(true);
            }

        }


        // each guard tower needs vectors, so should find vector of current guard tower and add units to get to find top of guard tower
        //public static Vector3 WithX(this Vector3 vector, float x)
        //{
        //    return new Vector3(x, vector.y, vector.z);
        //}

        //public static Vector3 WithY(this Vector3 vector, float y)
        //{
        //    return new Vector3(vector.x, y, vector.z);
        //}

        //public static Vector3 WithZ(this Vector3 vector, float z)
        //{
        //    return new Vector3(vector.x, vector.y, z);
        //}

        // transform.position = transform.position.WithX(Random.Range(-11, 12));

        //void CollectTourniquet()
        //{

        //    Debug.Log("Pick up tourniquet, show image in Fungus.");

        //}

    }
}