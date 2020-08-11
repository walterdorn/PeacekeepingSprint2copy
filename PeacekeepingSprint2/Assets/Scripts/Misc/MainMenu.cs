using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  //method to load in the next scene, being the Main_Scene
  public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //after menu button is pressed, call this method and quit game
    public void QuitGame()
    {
        Application.Quit();
    }

}
