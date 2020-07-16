using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for updating slider:
using UnityEngine.UI;
// Text Mesh Pro:
using TMPro;


// modified from https://www.youtube.com/watch?v=DAXgs7kTYQg 
// "Unity Tutorial - How to create Binoculars" by WatchFindDo Media - Jan 26 2019
public class Binoculars : MonoBehaviour
{    
    [SerializeField] float zoomFOV = 15.0f;
    [SerializeField] float defaultFOV = 60.0f;

    [SerializeField] int zoomSpeed = 10;
    [SerializeField] bool smoothZoom = true;
    [SerializeField] float smoothSpeed = 5.0f;

    [SerializeField] KeyCode toggleKey = KeyCode.B;

    // for Zoom / Field of View
    [SerializeField] Camera mainCamera = null;
    [SerializeField] Camera guardBinocularCamera = null;

    // For going between states of the BlackScreen
    [SerializeField] Animator animator = null;

    // need some UI references:
    [SerializeField] CanvasGroup canvasGroup = null;
    
    // for updating slider
    [SerializeField] Slider zoomSlider = null;
    [SerializeField] TextMeshProUGUI zoomFOVText = null;
    [SerializeField] TextMeshProUGUI defaultFOVText = null;
    [SerializeField] TextMeshProUGUI currentFOVText = null;
       
    [SerializeField, HideInInspector]
    private bool isActive = false;

    // for Zoom
    [SerializeField, HideInInspector]
    private float currentFOV = 0.0f;    

    // to set FOV, need boolean so don't fade out while currently fading in and vice versa
    private bool isFading = false;

    private IEnumerator IE_Fade = null;

    // For going between states of the BlackScreen
    private int blackScreenStateParameterHash = 0;

    // variable for the binocular first person camera
    public GameObject binocCamera;

    //variable for hiding the minimap while using binoculars
    public GameObject minimapCanvas;

    // variable for hiding the reputation bar while using binoculars
    public GameObject reputationBar;



    void Start()
    {
       
        Reset();

        // "cache in" ? the hash
        // string to hash generates a parameter ID from a string
        blackScreenStateParameterHash = Animator.StringToHash("BlackScreen_State");
           

        // assign the zoomFOV and defaultFOV info so don't end up with so many decimals
        zoomFOVText.text = (zoomFOV / 10).ToString();
        defaultFOVText.text = (defaultFOV / 10).ToString();

        // set slider min and max values
        zoomSlider.minValue = zoomFOV;
        zoomSlider.maxValue = defaultFOV;
        zoomSlider.value = currentFOV;

        // start the camera false because we dont want to be in them right away
        binocCamera.SetActive(false);

        // turn off the UI in the beginning of the game
        canvasGroup.alpha = 0;

    }

    void Update()
    {
        
        // if press key and currently not fading
        if (Input.GetKeyDown(toggleKey) && !isFading)
        {
            isFading = true;
            // when toggle key is down, run Toggle method

           
            Toggle();
        }
        //only want to update zoom when binoculars are active
        if(isActive)
        {
            UpdateZoom();
        }       
    }

    public void Toggle()
    {
        // binocCamera.SetActive(true);
        // make boolean equal to opposite state (swap from true to false or vice versa)
        isActive = !isActive;

        // check if anything assigned to IEnumerator variable
        if (IE_Fade != null)
        {
            // if not null, means coroutine is running currently
            // so stop coroutine so can run it again
            StopCoroutine(IE_Fade);
        }
        // assign Fade() to IEnumerator variable IE_Fade and pass in parameter isActive
        IE_Fade = Fade(isActive);
        // start coroutine and pass in IE_Fade variable
        StartCoroutine(IE_Fade);
    }
    
    void UpdateZoom()
    {
        bool changeWasMade = false;

        // use scroll wheel to zoom
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("Used Mousewheel in Binoculars script");
            // Zoom In
            // don't want to exceed a certain limit, so clamp (value, min, max)
            currentFOV = Mathf.Clamp(currentFOV + zoomSpeed, zoomFOV, defaultFOV);
            changeWasMade = true;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            // Zoom Out
            currentFOV = Mathf.Clamp(currentFOV - zoomSpeed, zoomFOV, defaultFOV);
            changeWasMade = true;
        }

        if (changeWasMade)
        {
            // only want to update this when there is a change
            // changeWasMade will be true whenever use mouse wheel
            UpdateUI();
        }

        UpdateFOV(smoothZoom);
        UpdateFOVGuardTowerBinoculars(smoothZoom);
    }

    public void UpdateUI()
    {
        //Want to update our current FOV info
        // check if currentFOVText object is referenced
        if (currentFOVText)
        {
            // divide default and current then convert to a string.
            // "N" will format the string so will have less decimal numbers
            currentFOVText.text = (defaultFOV / currentFOV).ToString("N") + "X"; 

        }
    }

    // parameter smoothUpdate added for Reset()
    public void UpdateFOV(bool smoothUpdate)
    {
        // want to smoothly zoom in
        if (smoothUpdate)
        {
            // check if have assigned main camera
            if (mainCamera)
            {
                // interpolate between 
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, currentFOV, Time.deltaTime * smoothSpeed);
            }
            if (zoomSlider)
            {
                zoomSlider.value = Mathf.Lerp(zoomSlider.value, currentFOV, Time.deltaTime * smoothSpeed);
            }
        }
        else
        {
            if (mainCamera)
            {
                mainCamera.fieldOfView = currentFOV;
            }
            if (zoomSlider)
            {
                zoomSlider.value = currentFOV;
            }
        }
    }

    // parameter smoothUpdate added for Reset()
    public void UpdateFOVGuardTowerBinoculars(bool smoothUpdate)
    {
        // want to smoothly zoom in
        if (smoothUpdate)
        {
            // check if have assigned main camera
            if (guardBinocularCamera)
            {
                // interpolate between 
                guardBinocularCamera.fieldOfView = Mathf.Lerp(guardBinocularCamera.fieldOfView, currentFOV, Time.deltaTime * smoothSpeed);
            }
            if (zoomSlider)
            {
                zoomSlider.value = Mathf.Lerp(zoomSlider.value, currentFOV, Time.deltaTime * smoothSpeed);
            }
        }
        else
        {
            if (guardBinocularCamera)
            {
                guardBinocularCamera.fieldOfView = currentFOV;
            }
            if (zoomSlider)
            {
                zoomSlider.value = currentFOV;
            }
        }
    }

    // use the parameter "state" to decide whether to fade in or fade out the binoculars
    IEnumerator Fade(bool state)
    {
        if (!state)
        {
            // if fading in the binoculars: state is 2
            animator.SetInteger(blackScreenStateParameterHash, 2);
            yield return new WaitForSeconds(0.225f);
        }

        // switch our state: so if case is true, fade in binoculars
        switch (state)
        {
            case true:
                // check if canvas alpha is less than 0
                while (canvasGroup.alpha < 1)
                {
                    // hide minimap while binoculars active
                    minimapCanvas.SetActive(false);

                    // hide peace indicator / rep bar while binoculars are active
                    reputationBar.SetActive(false);

                    // switch on binocular camera
                    binocCamera.SetActive(true);

                    canvasGroup.alpha += 10 * Time.deltaTime;
                    yield return null;
                }
                break;

            case false:
                // check if canvas alpha is more than 0
                // if more than zero, it means the canvas hasn't fully faded out
                while (canvasGroup.alpha > 0)
                {
                    // reveal minimap while binoculars not active
                    minimapCanvas.SetActive(true);

                    // reveal peace indicator / rep bar while binoculars not active
                    reputationBar.SetActive(true);

                    // switch from binocular camera
                    binocCamera.SetActive(false);
                    
                    // so subtract the alpha
                    canvasGroup.alpha -= 10f * Time.deltaTime;
                    yield return null;
                }
                break;
        }


        // for fading black screen
        Reset();
        if (!state)
        {
            yield return new WaitForSeconds(.1f);
            animator.SetInteger(blackScreenStateParameterHash, 1);
        }

        isFading = false;
    }

    // this is Unity's function, same as hitting the cog in Inspector and reseting a component
    void Reset()
    {
        // called at start of game
        currentFOV = defaultFOV;
        UpdateFOV(false);
        UpdateFOVGuardTowerBinoculars(false);
        UpdateUI();       
    }

}
