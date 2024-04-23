using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    GameObject plyr;
    void Update()
    {
        if(Controller.InRange == gameObject && Vector3.Distance(transform.position, plyr.transform.position) > 3)
        {
            Controller.InRange = null;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            plyr = col.gameObject;
            Controller.InRange = gameObject;
        }
    }
}
