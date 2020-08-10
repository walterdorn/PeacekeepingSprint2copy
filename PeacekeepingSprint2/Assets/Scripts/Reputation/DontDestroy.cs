using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    //originally used to track reputation through scene changes, but project now only uses the "Main Scene"

    private static DontDestroy instance;

    void Awake()
    {

       // DontDestroyOnLoad(this.gameObject);

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
