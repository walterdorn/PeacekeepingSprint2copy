using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffDialogue : MonoBehaviour
{    
   
    public GameObject SecondCircle;
    public GameObject VillageCircle1;
    public GameObject VillageCircle2;
    public GameObject VillageCircle3;
    public GameObject VillageCircle4;
    public GameObject VillageCircle5;

    public GameObject FinalBaseCircle;

    public int VillagersTalkedTo;

    // Start is called before the first frame update
    void Start()
    {
        // start with all villager dialogue set to false
        VillageCircle1.SetActive(false);
        VillageCircle2.SetActive(false);
        VillageCircle3.SetActive(false);
        VillageCircle4.SetActive(false);
        VillageCircle5.SetActive(false);
        SecondCircle.SetActive(false);
        FinalBaseCircle.SetActive(false);

        VillagersTalkedTo = 0;

    }

    // after talking to all five people the campfire spawns
    private void Update()
    {
        if(VillagersTalkedTo >= 5)
        {

            FinalBaseCircle.SetActive(true);
            SecondCircle.SetActive(false);

        }
    }

    // this is called to turn on the village circles after accepting the mission
    void TurnOnVillageDialogue()
    {
        VillageCircle1.SetActive(true);
        VillageCircle2.SetActive(true);
        VillageCircle3.SetActive(true);
        VillageCircle4.SetActive(true);
        VillageCircle5.SetActive(true);  

    }

    // these are called in fungus dialogue to turn off different dialogue circles
    void TurnDialogue1Off()
    {
        VillageCircle1.SetActive(false);

        VillagersTalkedTo = VillagersTalkedTo + 1;     

    }

    void TurnDialogue2Off()
    {
      
        VillageCircle2.SetActive(false);

        VillagersTalkedTo = VillagersTalkedTo + 1;

    }

    void TurnDialogue3Off()
    {
       
        VillageCircle3.SetActive(false);

        VillagersTalkedTo = VillagersTalkedTo + 1;

    }

    void TurnDialogue4Off()
    {
      
        VillageCircle4.SetActive(false);

        VillagersTalkedTo = VillagersTalkedTo + 1;

    }

    void TurnDialogue5Off()
    {
        
        VillageCircle5.SetActive(false);

        VillagersTalkedTo = VillagersTalkedTo + 1;
    }


}
