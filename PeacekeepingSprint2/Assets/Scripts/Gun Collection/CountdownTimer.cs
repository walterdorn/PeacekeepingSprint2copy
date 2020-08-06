using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public float currentTime = 0f;
    float startingTime = 200f;
    bool repChange = true;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");


        if(currentTime <= 0)
        {

            currentTime = 0;

            if (repChange == true)
            {

                //GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().RepDecreaseBig();
                repChange = false;
            }
        }
    }

}
