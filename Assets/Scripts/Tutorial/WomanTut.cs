using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WomanTut : MonoBehaviour
{
    int Happiness = 100;
    public int MaxHappiness = 100;
    bool touchingPlayer;
    public static bool charming = false;
    bool resetting = false;
    float perfect = 8;
    public Charm charm;
    public Sprite[] madness;
    public GameObject ladyface, quip;
    public RectTransform bar;
    public ParticleSystem hearts;
    float extent, barextent;
    public AudioSource charmsound;
    // Start is called before th
    // pe first frame update
    void Start()
    {
        Happiness = MaxHappiness;
        StartCoroutine("LoseHappiness");
        charm.transform.gameObject.SetActive(false);
        extent = (float)ladyface.GetComponent<RectTransform>().sizeDelta.x / (float)2f;
        barextent = (float)bar.sizeDelta.x / (float)2f;
    }

    // Update is called once per frame
    IEnumerator LoseHappiness()
    {
        yield return new WaitForSeconds(1);
        if (TutorialFairy.index == 2)
        {
            Happiness--;
        }
        StartCoroutine("LoseHappiness");
    }
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = madness[(int)Mathf.Round(Mathf.Lerp(0, madness.Length-1, (float)Happiness/(float)MaxHappiness))];
        if(Happiness <= 0)
        {
            Happiness = 0;
        }
        else if(Happiness >= MaxHappiness)
        {
            Happiness = MaxHappiness;
        }
        if(touchingPlayer && Input.GetMouseButtonDown(0) && Controller.heldObject == null)
        {
            if (!charming)
            {
                Charm();
            }
            else if (charming && !resetting)
            {
                StartCoroutine("reset");
                resetting = true;
            }
        }
        float x = Mathf.Lerp(-barextent + extent, barextent - extent, (float)Happiness / MaxHappiness);
        ladyface.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, ladyface.GetComponent<RectTransform>().anchoredPosition.y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            touchingPlayer = true;
        }
        else if(col.gameObject.tag == "Rose")
        {
            TakeRose();
            Destroy(col.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        touchingPlayer = false;
    }
    void Charm()
    {
        charm.transform.gameObject.SetActive(true);
        charm.charmSpeed = Mathf.Lerp(0.5f,5,(float)((float)(MaxHappiness-Happiness) / MaxHappiness));
        charming = true;
        Controller.stopped = true;
        charmsound.Play();
    }
    void TakeRose()
    {
        MaxHappiness += 10;
        Happiness += 10;
        hearts.Play();
        GetComponent<AudioSource>().Play();
    }
    IEnumerator reset()
    {
        charmsound.Stop();
        int c = charm.CalculateCharm();
        if(TutorialFairy.index == 2 && TutorialFairy.waiting)
        {
            Debug.Log("added");
            TutorialFairy.index++;
            TutorialFairy.waiting = false;
        }
        if(c >= 50 - perfect && c <= 50 + perfect)
        {
            GetComponent<AudioSource>().Play();
            c = MaxHappiness;
            hearts.Play();
        }
        Happiness += c;
        GameObject q = Instantiate(quip, transform.position, transform.rotation);
        q.GetComponent<Quip>().Quipped(c, MaxHappiness);
        yield return new WaitForSeconds(0.5f);
        HardReset();
        StopCoroutine("reset");
    }
    void HardReset()
    {
        charm.stopped = false;
        charming = false;
        charm.transform.gameObject.SetActive(false);
        resetting = false;
        Controller.stopped = false;
    }
}
