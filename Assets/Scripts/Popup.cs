using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    public string text;
    public bool activate = false;
    GameObject ply;
    void Awake()
    {
        if (activate)
        {
            Money.instance = Instantiate(popup, transform.position, popup.transform.rotation);
            Money.instance.GetComponentInChildren<Canvas>().sortingOrder = 6;
            Money.instance.SetActive(false);
        }
    }
    void Update()
    {
        if (activate)
        {
            Money.instance.transform.position = GameObject.FindWithTag("Player").transform.position - new Vector3(0, 2.25f, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Money.instance.SetActive(true);
            Money.instance.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Money.instance.SetActive(false);
        }
    }
}
