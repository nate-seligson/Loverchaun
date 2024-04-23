using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public static bool instore = false;
    public bool touching = false;
    public GameObject store;
    void Start()
    {
        store.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!instore && touching)
            {
                EnterStore();
            }
        }
    }
    void EnterStore()
    {
        instore = true;
        Controller.stopped = true;
        store.SetActive(true);
    }
    public void ExitStore()
    {
        instore = false;
        Controller.stopped = false;
        store.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            touching = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            touching = false;
        }
    }
}
