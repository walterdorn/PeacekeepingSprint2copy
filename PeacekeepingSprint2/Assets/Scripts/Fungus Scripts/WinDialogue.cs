using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDialogue : MonoBehaviour
{

    public void WinGame()
    {

        SceneManager.LoadScene("Win Scene");
    }

    //if the player character enters the dialogue circle, start dialogue and transition to main menu
    private void OnTriggerEnter(Collider other)
    {

        Fungus.Flowchart.BroadcastFungusMessage("WinDialogue");
    }
}
