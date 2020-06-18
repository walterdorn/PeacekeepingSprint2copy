using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReputationBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetRep(int rep)
    {

        slider.value = rep;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            SceneManager.LoadScene("test");
        }
    }
}
