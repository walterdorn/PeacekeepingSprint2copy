using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationBar : MonoBehaviour
{

    private static ReputationBar instance;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetRep(int rep)
    {

        slider.value = rep;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
