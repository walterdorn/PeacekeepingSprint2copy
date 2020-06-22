using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ReputationCalculation : MonoBehaviour
{

    public int maxRep;
    public int minRep;
    public int currentRep;

    public ReputationBar repBar;

    // Start is called before the first frame update
    void Start()
    {

        currentRep = 50;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {

            ChangeRep(10);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            ChangeRep(-10);
        }

    }

    void ChangeRep(int rep)
    {

        currentRep += rep;
        repBar.SetRep(currentRep);

        if (currentRep >= 100)
        {

            currentRep = 100;
        }

        if (currentRep <= 0)
        {

            currentRep = 0;
        }
    }

    public void RepIncreaseSmall()
    {

        ChangeRep(10);
        Debug.Log("RepIncreaseSmall +10");
    }

    public void RepDecreaseSmall()
    {

        ChangeRep(-10);
        Debug.Log("RepDecreaseSmall -10");
    }

    public void RepIncreaseBig()
    {

        ChangeRep(20);
        Debug.Log("RepIncreaseBig 20");
    }

    public void RepDecreaseBig()
    {

        ChangeRep(-20);
        Debug.Log("RepDecreaseBig -20");
    }
}
