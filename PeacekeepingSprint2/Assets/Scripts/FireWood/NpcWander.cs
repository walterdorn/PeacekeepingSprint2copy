using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcWander : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    public bool playAnimation = true;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(isWandering == false)
        {
            StartCoroutine(Wander());
        } 
      if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            playAnimation = false;
            anim.enabled = false;
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            playAnimation = false;
            anim.enabled = false;
        }
        if(isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            playAnimation = true;
            
        }

        if (playAnimation == true)
        {
            anim.enabled = true;
        }

        if(playAnimation == false)
        {
            anim.enabled = false;
        }
    }


    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(3, 6);
        int rotateLorR = Random.Range(1,2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        isWandering = false;

    }
}
