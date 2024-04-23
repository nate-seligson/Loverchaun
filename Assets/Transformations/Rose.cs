using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.gameObject.GetComponent<Health>())
        {
            col.transform.gameObject.GetComponent<Health>().RemoveHealth(75);
        }
    }
}
