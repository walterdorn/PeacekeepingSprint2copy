using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ReputationCalculation : MonoBehaviour
{

    public int maxRep;
    public int minRep;
    public int currentRep;
    public int currentRep2;

    public ReputationBar repBar;
    public ReputationBar repBar2;

    // Start is called before the first frame update
    void Start()
    {

        currentRep = 50;
        currentRep2 = 50;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {

            ChangeRep(10, -10);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            ChangeRep(-10, 10);
        }

    }

    void ChangeRep(int rep, int rep2)
    {

        currentRep += rep;
        currentRep2 += rep2;

        repBar.SetRep(currentRep);
        repBar2.SetRep(currentRep2);

        if (currentRep >= 100)
        {

            currentRep = 100;
        }

        if (currentRep <= 0)
        {

            currentRep = 0;
        }

        if (currentRep2 >= 100)
        {

            currentRep2 = 100;
        }

        if (currentRep2 <= 0)
        {

            currentRep2 = 0;
        }
    }

    public void RepIncreaseTiny()
    {

        ChangeRep(5, -5);
    }

    public void RepDecreaseTiny()
    {

        ChangeRep(-5, 5);
    }

    public void RepIncreaseSmall()
    {

        ChangeRep(10, -10);
    }

    public void RepDecreaseSmall()
    {

        ChangeRep(-10, 10);
    }

    public void RepIncreaseBig()
    {

        ChangeRep(20, -20);
    }

    public void RepDecreaseBig()
    {

        ChangeRep(-20, 20);
    }
}
