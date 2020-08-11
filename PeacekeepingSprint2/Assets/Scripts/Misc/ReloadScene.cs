using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        //if the key R is pressedd, reload the scene, meant to be used in the Main_Scene, also resets approval/reputation
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("Reload Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
