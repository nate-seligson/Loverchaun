using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationTut : MonoBehaviour
{
    public TransformData data;
    public bool transformed = false;
    public AudioSource hitsound;
  
    // Update is called once per frame
    void Update()
    {
        GetComponent<Popup>().text = "[E] Charm";
        if(Input.GetKeyDown(KeyCode.E) && Controller.InRange == gameObject && !transformed)
        {
            if (Unlocks.unlocks[data.UnlockName])
            {
                Transform();
                if((TutorialFairy.index == 7 || TutorialFairy.index == 6))
                {
                    TutorialFairy.index = 8;
                    TutorialFairy.waiting = false;
                }
                GetComponent<AudioSource>().Play();
                transformed = true;
            }
            else {
                Debug.Log("not unlocked");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Controller.InRange = gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Controller.InRange = null;
        }
    }
    void Transform()
    {
        gameObject.AddComponent(System.Type.GetType(data.ScriptName));
        Health();
        GetComponent<Collider2D>().isTrigger = false;
        Destroy(GetComponent<Pickupable>());
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<Animator>().SetTrigger("transform");

    }
    void Health()
    {
        gameObject.AddComponent<Health>();
        GetComponent<Health>().health = data.health;
        GetComponent<Health>().hitsound = hitsound; 
    }
}
