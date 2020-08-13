using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        //if the key R is pressed, return to main menu
        if (Input.GetKeyDown("r"))
        {
           // Debug.Log("Reload Scene");
            SceneManager.LoadScene("Menu");
        }
    }

    //method to return to main menu
    public void ReturnToMenu()
    {

        SceneManager.LoadScene("Menu");
    }
}
