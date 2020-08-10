using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ReputationCalculation : MonoBehaviour
{

    //variables
    public int maxRep;
    public int minRep;
    public int ManancaRep;
    public int KamboRep;

    //reference to reputation bars in main canvas
    public ReputationBar repBar;
    public ReputationBar repBar2;

    // Start is called before the first frame update
    void Start()
    {

        //set starting reputation of both villages
        ManancaRep = 50;
        KamboRep = 50;

    }

    // Update is called once per frame
    void Update()
    {

        //shortcuts to test reputation
        if (Input.GetKeyDown(KeyCode.P))
        {

            //mananca up, kambo down
            ChangeRep(10, -10);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            //mananca down, kambo up
            ChangeRep(-10, 10);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            //both up
            ChangeRep(10, 10);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {

            //both down
            ChangeRep(-10, -10);
        }

    }

    //method to be referenced to change the reputation - set limits to reputation
    void ChangeRep(int rep, int rep2)
    {

        //reputation variables, reference to reputation bar method
        ManancaRep += rep;
        KamboRep += rep2;
        repBar.SetRep(ManancaRep);
        repBar2.SetRep(KamboRep);

        //limits
        if (ManancaRep >= 100)
        {

            ManancaRep = 100;
        }

        if (ManancaRep <= 0)
        {

            ManancaRep = 0;
        }

        if (KamboRep >= 100)
        {

            KamboRep = 100;
        }

        if (KamboRep <= 0)
        {

            KamboRep = 0;
        }
    }

    //increase Mananca reputation by 40, decrease Kambo by 20 --- UNMNO Attack on Civilians Quest Reward
    public void UNMOMissionReward()
    {

        ChangeRep(40, -20);
    }

    //Increase Kambo reputation by 40, decrease Mananca by 10 --- Gun Collection Quest Reward
    public void GunCollectionMissionReward()
    {

        ChangeRep(10, 40);
    }

    //increase Kambo by 30 --- First Aid Quest Reward
    public void FirstAidMissionReward()
    {

        ChangeRep(-20, 30);
    }

}
