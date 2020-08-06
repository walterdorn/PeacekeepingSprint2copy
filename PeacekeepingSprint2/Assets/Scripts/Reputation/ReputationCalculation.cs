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

            ChangeRep(10, -10);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            ChangeRep(-10, 10);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            ChangeRep(10, 10);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {

            ChangeRep(-10, -10);
        }

    }

    //method to be referenced to change the reputation - set limits to reputation
    void ChangeRep(int rep, int rep2)
    {

        ManancaRep += rep;
        KamboRep += rep2;

        repBar.SetRep(ManancaRep);
        repBar2.SetRep(KamboRep);

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

    //increase Mananca reputation by 40, decrease Kambo by 20
    public void UNMOMissionReward()
    {

        ChangeRep(40, -20);
    }

    //Increase Kambo reputation by 40, decrease Mananca by 10
    public void GunCollectionMissionReward()
    {

        ChangeRep(40, -10);
    }

    //increase Kambo by 30
    public void FirstAidMissionReward()
    {

        ChangeRep(30, 0);
    }

}
