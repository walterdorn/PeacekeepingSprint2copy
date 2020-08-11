using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscortCollider : MonoBehaviour
{
    public float timer;
    public bool TimerOn;

    public bool Rep;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = false;
        Rep = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(TimerOn == true)
        {

            StartTimer();
        }
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("I am colliding");
            timer = 0;
            TimerOn = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        TimerOn = true;
        
        

           // Debug.Log("ACHOO");
        
        
    }

    void StartTimer()
    {
    //    timer +=  Time.deltaTime;

    //    if (timer >= 10)
    //    {
    //        //Debug.Log("You Lose");
    //        // mission fail rep decrease

    //        if(Rep == true)
    //        {
    //            GameObject.Find("ReputationBar").GetComponent<ReputationCalculation>().RepDecreaseBig();
    //            Rep = false;

    //            SceneManager.LoadScene("Main_Scene");
    //        }
            
    //    }


    }

    
}
