using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float speed = 5;
    public static GameObject InRange;
    public static GameObject heldObject;
    public Transform holdSpot;
    bool holding;
    public static bool stopped = false;
    float input;
    Animator an;
    public AudioSource step, place;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }
    void Update()
    {
        Animate();
        if (!stopped)
        {
            input = Input.GetAxis("Horizontal");
        }
        else
        {
            input = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!holding)
            {
                Hold();
                
            }
            else
            {
                LetGo();
                place.Play();
            }
        }
        if(holding && heldObject == null)
        {
            holding = false;
        }
    }
    void Animate()
    {
        if (Mathf.Abs(input) >= 0.1)
        {
            if (!an.GetBool("walking"))
            {
                StartCoroutine("walksounds");
            }
            an.SetBool("walking", true);
            
        }
        else
        {
            StopCoroutine("walksounds");
            an.SetBool("walking", false);
        }
        if (holding)
        {
            an.SetBool("holding", true);
        }
        else
        {
            an.SetBool("holding", false);
        }
        if (Woman.charming)
        {
            an.SetBool("Flirt", true);
        }
        else
        {
            an.SetBool("Flirt", false);
        }
    }
    IEnumerator walksounds()
    {
        yield return new WaitForSeconds(0.28f);
        step.Play();
        StartCoroutine("walksounds");
    }
    void Hold()
    {
        if (!InRange.GetComponent<Pickupable>())
        {
            return;
        }
        heldObject = InRange;
        InRange = null;
        holding = true;
        place.Play();
        heldObject.transform.position = holdSpot.position;
        heldObject.transform.parent = transform;
        heldObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    public void LetGo()
    {
        heldObject.transform.parent = null;
        heldObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        SpawnObjects.PutDown(heldObject);
        heldObject = null;
        holding = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(input, 0, 0);
        transform.position = transform.position + move * Time.deltaTime * speed;
        HandleFlipperonis(input);
    }
    void HandleFlipperonis(float input)
    {
        float flip = transform.localScale.x;
        if((input < -0.1 && flip > 0) || (input>0.1 && flip<0))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Shop")
        {
            InRange = null;
        }
    }
}
